using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
abstract class BaseStorage: MonoBehaviour {

	public abstract Capacity MaxCapacity { get; }
	public abstract Capacity CurrentMaxCapacity { get; }
	public abstract Capacity AvailableCapacity { get; }

	public abstract bool Contains(IStorable obj);
	/// <summary>
	/// return 0 when storage doesn't contains <paramref name="obj"/>
	/// </summary>
	public abstract int CountOfObjectInStorage(IStorable obj);
	public abstract bool TryAddObject(IStorable obj);
	public abstract bool TrySubObject(IStorable obj);
	public abstract void OnDamage(ShipParts oldHitPoints, ShipParts newHitPoints);
	/// <summary>
	/// when there is no space and e.g. storage get damage
	/// </summary>
	public abstract void DestroyRandomObject();
	public abstract List<T> GetObjectsByType<T>();
	public abstract IEnumerable<IStorable> GetObjects();
}

interface IStorable {
	String Name { get; }
	Capacity Capacity { get; }
}

class Storage : BaseStorage {
	/// <summary>
	/// Dictionary is much more faster than List when deleting/adding elements many times
	/// </summary>
	Dictionary<IStorable, int> _collection;
	public	Capacity _maxCapacity;
    Capacity currentMaxCapacity, availableCapacity;

	
	public override Capacity MaxCapacity {
		get { return _maxCapacity; }
	}
	public override Capacity CurrentMaxCapacity {
		get { return availableCapacity; }
	}
	public override Capacity AvailableCapacity {
		get { return availableCapacity; }
	}

	public Storage(Capacity maxCapacity) {
		_maxCapacity = maxCapacity;
		currentMaxCapacity = maxCapacity;
		availableCapacity = maxCapacity;
		_collection = new Dictionary<IStorable, int>();
	}

	public void Awake()
	{
		currentMaxCapacity = MaxCapacity;
		availableCapacity = MaxCapacity;
		_collection = new Dictionary<IStorable, int>();
	}

	public override bool Contains(IStorable obj) {
		return _collection.Keys.Contains(obj);
	}

	public override int CountOfObjectInStorage(IStorable obj) {
		if (!this.Contains(obj)) {
			return 0;
		}
		return _collection[obj];
	}

	public override bool TryAddObject(IStorable obj) {
		if (obj.Capacity > this.AvailableCapacity) {
			return false;
		}
		if (this.Contains(obj))
			_collection[obj]++;
		else
			_collection.Add(obj, 1);
		this.availableCapacity -= obj.Capacity;
		return true;
	}

	public override bool TrySubObject(IStorable obj) {
		if (!this.Contains(obj)) {
			return false;
		}
		_collection[obj]--;
		if (_collection[obj] == 0)
			_collection.Remove(obj);
		this.availableCapacity -= obj.Capacity;
		return true;
	}

	public override void DestroyRandomObject() {
		int count = _collection.Count;
		Dictionary<IStorable, int>.Enumerator enumerator = _collection.GetEnumerator();
		for (int i = 0; i < (new System.Random()).Next(1, count); i++) {
			enumerator.MoveNext();
		}
		this.availableCapacity -= enumerator.Current.Key.Capacity;
		_collection.Remove(enumerator.Current.Key);
	}

	public override List<T> GetObjectsByType<T>() {
		List<T> resultCollection = new List<T>();
		foreach (var item in _collection)
			if (item.Key.GetType() is T)
				resultCollection.Add((T)item.Key);
		return resultCollection;
	}

	public override IEnumerable<IStorable> GetObjects() {
		foreach (var item in _collection)
			yield return item.Key;
	}

	public override void OnDamage(ShipParts oldHitPoints, ShipParts newHitPoints) {
		if(newHitPoints == oldHitPoints)
			return;
		Capacity newCurrentMaxCapacity = newHitPoints / oldHitPoints * CurrentMaxCapacity;
		if (MaxCapacity < newCurrentMaxCapacity){
				currentMaxCapacity = MaxCapacity;
		}
		else {
			while (AvailableCapacity + CurrentMaxCapacity - newCurrentMaxCapacity < 0) {
				DestroyRandomObject();
			}
			currentMaxCapacity = newCurrentMaxCapacity;
		}
	}
}
