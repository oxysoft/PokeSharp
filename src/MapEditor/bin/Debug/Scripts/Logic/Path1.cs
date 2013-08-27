using System;
using General.Script;
using MapEditor.Data.TileLogicNew;

public class Path1 : IScript {

	const string tname = "Outside";
	const int x = 1;
	const int y = 0;

	//Function called when initializing logics
	public void Load(TileLogicScript logic) {
		logic.name = "Grass1";
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

	//Function called when painting with logic tile
	public void Eval(TileLogicScript logic, LogicEvalInfo info, bool u, bool d, bool l, bool r, bool ul, bool ur, bool dl, bool dr) {
		info.Adjust(tname, x + 1, y + 1);

		if (!u) {
			if (!l) info.Adjust(tname, x, y);
			else if (!r) info.Adjust(tname, x + 2, y);
			else info.Adjust(tname, x + 1, y + (dl ? 0 : ul ? 2 : 0));
		} else if (!d) {
			if (!l) info.Adjust(tname, x, y + 2);
			else if (!r) info.Adjust(tname, x + 2, y + 2);
			else info.Adjust(tname, x + 1, y + 2);
		} else if (u) {
			if (!l) info.Adjust(tname, x, y + 1);
			else if (!r) info.Adjust(tname, x + 2, y + 1);
		}	

		if (u && d && l && r) {
			if (!ul) info.Adjust(tname, x + 3, y);
			else if (!ur) info.Adjust(tname, x + 4, y);
			else if (!dl) info.Adjust(tname, x + 3, y + 1);
			else if (!dr) info.Adjust(tname, x + 4, y + 1);
		}

		if (u && d && l && r && ul && ur && dl && dr) {
			info.Adjust(tname, x + 1, y + 1); //midle
		}

	}

}