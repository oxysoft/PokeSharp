var tname = "HGSS_Outdoor";
var x = 0;
var y = 0;

function Load(logic) {
	logic.name = "Grass";

	logic.s_0 = tname;
	logic.s_1 = 0;

	logic.addSameType(tname, x, y)
	logic.addSameType(tname, x, y + 1);
	logic.addSameType(tname, x, y + 2);
	logic.addSameType(tname, x, y + 3);
	logic.addSameType(tname, x, y + 4);
}

function Eval(logic, info, u, d, l, r, ul, ur, dl, dr) {
	info.Adjust(tname, x, y);
}