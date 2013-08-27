using General.Script;
using MapEditor.Data.TileLogicNew;

public class Grass : IScript {

	const string tname = "Outside";
	const int x = 0;
	const int y = 0;

	public void Load(TileLogicScript logic) {
		logic.name = "Grass";

		logic.s_0 = tname;
		logic.s_1 = 0;

		logic.addSameType(tname, x, y);
		logic.addSameType(tname, x, y + 1);
		logic.addSameType(tname, x, y + 2);
		logic.addSameType(tname, x, y + 3);
		logic.addSameType(tname, x, y + 4);
	}

	public void Eval(TileLogicScript logic, LogicEvalInfo info, bool u, bool d, bool l, bool r, bool ul, bool ur, bool dl, bool dr) {
		info.Adjust(tname, x, y);
	}

}