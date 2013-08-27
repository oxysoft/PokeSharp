public class Grass {

	public string name;
	public string tname = "HGSS_Outdoor";
	public int x = 1;
	public int y = 0;

	public void Initialize(TileLogicScript logic) {
		logic.name = name;
		logic.s_0 = tname;
		logic.s_1 = 1;

		logic.addSameType(tname, x + 0, y + 0);
		logic.addSameType(tname, x + 1, y + 0);
		logic.addSameType(tname, x + 2, y + 0);
		logic.addSameType(tname, x + 0, y + 1);
		logic.addSameType(tname, x + 1, y + 1);
		logic.addSameType(tname, x + 2, y + 1);
		logic.addSameType(tname, x + 0, y + 2);
		logic.addSameType(tname, x + 1, y + 2);
		logic.addSameType(tname, x + 2, y + 2);
		logic.addSameType(tname, x + 3, y + 0);
		logic.addSameType(tname, x + 4, y + 0);
		logic.addSameType(tname, x + 3, y + 1);
		logic.addSameType(tname, x + 4, y + 1);
	}

	public void Execute() {
	}

}