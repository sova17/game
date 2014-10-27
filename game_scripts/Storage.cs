using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
	abstract class TBaseStorage {

		public abstract TCapacity MaxCapacity { get; }
		public abstract TCapacity CurrentMaxCapacity { get; }
		public abstract TCapacity AvailableCapacity { get; }
		public abstract Boolean Contains(IStorable obj);
		/// <summary>
		/// return 0 when storage doesn't contains <paramref name="obj"/>
		/// </summary>
		public abstract Int32 CountOfObjectInStorage(IStorable obj);
		public abstract Boolean TryAddObject(IStorable obj);
		public abstract Boolean TrySubObject(IStorable obj);
		public abstract void OnDamage(TShipParts oldHitPoints, TShipParts newHitPoints);
		/// <summary>
		/// when there is no space and e.g. storage get damage
		/// </summary>
		public abstract void DestroyRandomObject();
		public abstract List<dynamic> GetObjectsByType(Type type);
		public abstract IEnumerable<IStorable> GetObjects();
	}

	class TCapacity {
		public Int32 Weight { get; private set; }
		public Int32 Space { get; private set; }
		public TCapacity(Int32 space, Int32 weight) {
			this.Weight = weight;
			this.Space = space;
		}
		public static Boolean operator >(TCapacity first, TCapacity second) {
			return first.Space > second.Space || (first.Space == second.Space && first.Weight > second.Weight);
		}
		public static Boolean operator <(TCapacity first, TCapacity second) {
			return second > first;
		}
		public static TCapacity operator -(TCapacity first, TCapacity second) {
			return new TCapacity(first.Space - second.Space, first.Weight - second.Weight);
		}
		public static TCapacity operator *(Double mult, TCapacity capacity) {
			return new TCapacity((Int32)(capacity.Space * mult), (Int32)(capacity.Weight * mult));
		}
		public static TCapacity operator +(TCapacity first, TCapacity second) {
			return new TCapacity(first.Space + second.Space, first.Weight + second.Weight);
		}
		public static Boolean operator <(TCapacity first, Int32 num) {
			return first.Weight < num && first.Space < num;
		}
		public static Boolean operator >(TCapacity first, Int32 num) {
			return first.Weight > num && first.Space > num;
		}
	}

	interface IStorable {
		String Name { get; }
		TCapacity Capacity { get; }
	}

	class TStorage : TBaseStorage {
		/// <summary>
		/// Dictionary is much more faster than List when deleting/adding elements many times
		/// </summary>
		Dictionary<IStorable, Int32> _collection;
		TCapacity _maxCapacity, _currentMaxCapacity, _availableCapacity;
		public TStorage(TCapacity maxCapacity) {
			this._maxCapacity = maxCapacity;
			this._currentMaxCapacity = maxCapacity;
			this._availableCapacity = maxCapacity;
			_collection = new Dictionary<IStorable, Int32>();
		}		
		public override TCapacity MaxCapacity {
			get { return this._maxCapacity; }
		}
		public override TCapacity CurrentMaxCapacity {
			get { return this._availableCapacity; }
		}
		public override TCapacity AvailableCapacity {
			get { return this._availableCapacity; }
		}

		public override Boolean Contains(IStorable obj) {
			return _collection.Keys.Contains(obj);
		}
		public override Int32 CountOfObjectInStorage(IStorable obj) {
			if (!this.Contains(obj)) {
				return 0;
			}
			return _collection[obj];
		}
		public override Boolean TryAddObject(IStorable obj) {
			if (obj.Capacity > this.AvailableCapacity) {
				return false;
			}
			if (this.Contains(obj))
				_collection[obj]++;
			else
				_collection.Add(obj, 1);
			this._availableCapacity -= obj.Capacity;
			return true;
		}
		public override Boolean TrySubObject(IStorable obj) {
			if (!this.Contains(obj)) {
				return false;
			}
			_collection[obj]--;
			if (_collection[obj] == 0)
				_collection.Remove(obj);
			this._availableCapacity -= obj.Capacity;
			return true;
		}
		public override void DestroyRandomObject() {
			int count = _collection.Count;
			Dictionary<IStorable, Int32>.Enumerator enumerator = _collection.GetEnumerator();
			for (int i = 0; i < (new Random()).Next(1, count); i++) {
				enumerator.MoveNext();
			}
			this._availableCapacity -= enumerator.Current.Key.Capacity;
			_collection.Remove(enumerator.Current.Key);
		}
		public override List<dynamic> GetObjectsByType(Type type) {
			Type list = typeof(List<>);
			var typeList = list.MakeGenericType(type);
			List<dynamic> resultCollection = (List <dynamic>)Activator.CreateInstance(typeList);
			foreach (var item in _collection)
				if (item.Key.GetType().Equals(type))
					resultCollection.Add(item);
			return resultCollection;
		}
		public override IEnumerable<IStorable> GetObjects() {
			foreach (var item in _collection)
				yield return item.Key;
		}
		public override void OnDamage(TShipParts oldHitPoints, TShipParts newHitPoints) {
			if(newHitPoints == oldHitPoints)
				return;
			TCapacity newCurrentMaxCapacity = newHitPoints / oldHitPoints * CurrentMaxCapacity;
			if (MaxCapacity < newCurrentMaxCapacity){
					_currentMaxCapacity = MaxCapacity;
			}
			else {
				while (AvailableCapacity + CurrentMaxCapacity - newCurrentMaxCapacity < 0) {
					DestroyRandomObject();
				}
				_currentMaxCapacity = newCurrentMaxCapacity;
			}
		}
	}
}
