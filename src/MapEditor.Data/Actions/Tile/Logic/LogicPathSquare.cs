namespace MapEditor.Data.Actions.Tile.Logic {
	public class LogicPathSquare {
		public int dir;
		public int x, y;

		 /*DIRECTION*/
		// 0      0
		//2 3 vs 3 1
		// 1      2
		//	 ????
		//WE WILL GO WITH FIRST
	
		public LogicPathSquare(int x, int y, int dir) {
			this.x = x;
			this.y = y;
			this.dir = dir;
		}
	}
}
