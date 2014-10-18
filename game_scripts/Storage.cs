using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
	abstract class TBaseStorage {
		public TCapacity MaxCapacity;
		public TCapacity CurrentMaxCapacity;
		public TCapacity AvailableCapacity;
		public abstract Boolean TryAddObject(IStorable obj);
		public abstract Boolean TrySubObject(IStorable obj);
		/// <summary>
		/// when there is no space and e.g. storage get damage
		/// </summary>
		public abstract void DestroyRandomObject();
		public abstract Int32 GetCountOfObjectInStorage(IStorable obj);
	}
	class TCapacity {
		public Int32 Weight { get; private set; }
		public Int32 Space { get; private set; }
		public static Boolean operator >(TCapacity first, TCapacity second) {
			throw new NotImplementedException();
		}
		public static Boolean operator <(TCapacity first, TCapacity second) {
			throw new NotImplementedException();
		}
		public static TCapacity operator -(TCapacity first, TCapacity second) {
			throw new NotImplementedException();
		}
	}
	interface IStorable {
		String GetName();
		TCapacity Capacity { get; }
	}
	class TStorage : TBaseStorage {
		Dictionary<IStorable, Int32> _collection;
		public TStorage(TCapacity maxCapacity) {
			this.MaxCapacity = maxCapacity;
			this.CurrentMaxCapacity = maxCapacity;
			this.AvailableCapacity = maxCapacity;
			_collection = new Dictionary<IStorable, Int32>();
		}
		public override Boolean TryAddObject(IStorable obj) {
			if (obj.Capacity > this.AvailableCapacity) {
				return false;
			}
			if (_collection.Keys.Contains(obj))
				_collection[obj]++;
			else
				_collection.Add(obj, 1);
			this.AvailableCapacity -= obj.Capacity;
			return true;
		}
		public override Boolean TrySubObject(IStorable obj) {
			if (!_collection.ContainsKey(obj)) {
				return false;
			}
			_collection[obj]--;
			if (_collection[obj] == 0)
				_collection.Remove(obj);
			this.AvailableCapacity -= obj.Capacity;
			return true;
		}
		public override void DestroyRandomObject() {
			int count = _collection.Count;
			Dictionary<IStorable, Int32>.Enumerator enumerator = _collection.GetEnumerator();
			for (int i = 0; i < (new Random()).Next(1, count); i++) {
				enumerator.MoveNext();
			}
			this.AvailableCapacity -= enumerator.Current.Key.Capacity;
			_collection.Remove(enumerator.Current.Key);
		}
		public override Int32 GetCountOfObjectInStorage(IStorable obj) {
			if (!_collection.Keys.Contains(obj)) {
				return 0;
			}
			return _collection[obj];
		}
	}
}
