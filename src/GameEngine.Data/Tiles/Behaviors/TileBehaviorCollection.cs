using System.Collections.Generic;
using System.Linq;

namespace GameEngine.Data.Tiles.Behaviors {
	public class TileBehaviorCollection : List<TileBehavior> {
		public static TileBehaviorCollection FromList(List<TileBehavior> l) {
			TileBehaviorCollection c = new TileBehaviorCollection();
			c.AddRange(l);
			return c;
		}

		public TileBehavior Get(byte id) {
			return this.FirstOrDefault(t => t.Id == id);
		}

		/// <summary>
		/// Returns a collection of behaviors container the tag.
		/// </summary>
		public TileBehaviorCollection Select(string tag) {
			return GetBehaviors(tag);
		}

		/// <summary>
		/// Returns a collection of behaviors containing the identifier and tag data.
		/// </summary>
		public TileBehaviorCollection Select(string identifier, object value) {
			return GetBehaviors(identifier, value);
		}

		/// <summary>
		/// Returns a collection of behaviors container the tag.
		/// </summary>
		public TileBehaviorCollection GetBehaviors(string tag) {
			return TileBehaviorCollection.FromList(this.Where(u => u.Tags.Contains(tag)).ToList());
		}

		/// <summary>
		/// Returns a collection of behaviors containing the identifier and tag data.
		/// </summary>
		public TileBehaviorCollection GetBehaviors(string identifier, object value) {
			TileBehaviorCollection c = new TileBehaviorCollection();
			c.AddRange(this.Where(t => t.Datas.Any(tuple => tuple.Item1 == identifier && tuple.Item2 == value)));
			return c;
		}
	}
}