--[[
luanet.load_assembly "Aeon_Editor"
luanet.import_type "Aeon_Editor.AeonEditor.TileLogicNew.LogicEvalInfo"
]]

function Load(logic)
	logic.name = "Path1"
	logic.s_0 = 0
	logic.s_1 = 19
	x = 5
	y = 0
	logic:addSameType(0, x + 0, y + 0)
	logic:addSameType(0, x + 1, y + 0)
	logic:addSameType(0, x + 2, y + 0)
	logic:addSameType(0, x + 0, y + 1)
	logic:addSameType(0, x + 1, y + 1)
	logic:addSameType(0, x + 2, y + 1)
	logic:addSameType(0, x + 0, y + 2)
	logic:addSameType(0, x + 1, y + 2)
	logic:addSameType(0, x + 2, y + 2)
	logic:addSameType(0, x + 3, y)
	logic:addSameType(0, x + 3, y + 1)
	logic:addSameType(0, x + 4, y)
	logic:addSameType(0, x + 4, y + 1)

end

function Eval(logic, info, u, d, l, r, ul, ur, dl, dr)
	info:Adjust(0, 19)
	i0 = 5
	i1 = 0

	iu = u and 1 or 0
	id = d and 1 or 0
	il = l and 1 or 0
	ir = r and 1 or 0
	iul = ul and 1 or 0
	iur = ur and 1 or 0
	idl = dl and 1 or 0
	idr = dr and 1 or 0

	--println("u: " .. iu .. ", d: " .. id .. ", l: " .. il .. ", r: " .. ir  .. ", ul: " .. iul .. ", ur: " .. iur .. ", dl: " .. idl .. ", dr: " .. idr);

	if not u then
		if not l then info:Adjust(0, i0, i1)
		elseif not r then info:Adjust(0, i0 + 2, i1)
		else info:Adjust(0, i0 + 1, i1 + (dl and 0 or ul and 2 or 0))
		end
	elseif not d then
		if not l then info:Adjust(0, i0, i1 + 2)
		elseif not r then info:Adjust(0, i0 + 2, i1 + 2)
		else info:Adjust(0, i0 + 1, i1 + 2)
		end
	elseif u then
		if not l then info:Adjust(0, i0, i1 + 1)
		elseif not r then info:Adjust(0, i0 + 2, i1 + 1)
		end
	end

	if u and d then
		if l and r and not ul then info:Adjust(0, i0 + 3, i1 + 0)
		elseif l and r and not dl then info:Adjust(0, i0 + 3, i1 + 1)
		elseif l and r and not ur then info:Adjust(0, i0 + 4, i1 + 0)
		elseif l and r and not dr then info:Adjust(0, i0 + 4, i1 + 1)
		end
	end

end

--[[272C2B
public static Pair<int, int> PathLogic(EditorMap map, int x, int y, int type) {
			Pair<int, int> result = new Pair<int, int>(-1, -1);

			if (d && u) {
				if (l && r && !ul && !ur) result = new Pair<int, int>(0, yindex);
				else if (l && r && !ur) result = new Pair<int, int>(3, yindex + 2);
				else if (l && r && !ul) result = new Pair<int, int>(4, yindex + 2);
				else if (l && r && !dr) result = new Pair<int, int>(1, yindex + 2);
				else if (l && r && !dl) result = new Pair<int, int>(2, yindex + 2);
				else if (u && d && l && r) result = new Pair<int, int>(0, yindex);
			}
			return result;
		}
]]