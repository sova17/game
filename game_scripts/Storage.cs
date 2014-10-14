using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_scripts {
	abstract class TBaseStorage {
		public abstract bool TryAddObject(IStorable obj);
		public abstract bool SubObject(IStorable obj);
		/// <summary>
		/// when there is no space and e.g. storage get damage
		/// </summary>
		public abstract void DestroyRandomObject();
		public TDimensions MaxCapacity;
		public TDimensions CurrentCapacity;
		public TDimensions AvailableCapacity;
	}
	class TDimensions {
		public Int32 Weight;
		public Int32 Space;
	}
	interface IStorable {
		string GetName();
		TDimensions GetDimensions();
	}
}
