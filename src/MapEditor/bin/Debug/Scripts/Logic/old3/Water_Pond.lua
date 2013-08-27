--Global variables
--Edit these if you do not know LUA and you want to adapt your own logics
tname = "HGSS_Outdoor"
x = 1
y = 6

--This function is called whenever the tile is 
function Load(logic)
	--The following code gives a name to our logic
	logic.name = "Water_Pond"

	--The following code define the display icon inside the logic tile selector window
	--s_0 is the tileset's name
	--s_1 is the tile index in the tileset
	logic.s_0 = tname
	logic.s_1 = 73
	
	--the following code define which tiles are considered as same type tiles
	--usage: "logic:addSameType(tileset name, X tile, Y tile)"
	logic:addSameType(tname, x + 0, y + 0)
	logic:addSameType(tname, x + 1, y + 0)
	logic:addSameType(tname, x + 2, y + 0)
	logic:addSameType(tname, x + 0, y + 1)
	logic:addSameType(tname, x + 1, y + 1)
	logic:addSameType(tname, x + 2, y + 1)
	logic:addSameType(tname, x + 0, y + 2)
	logic:addSameType(tname, x + 1, y + 2)
	logic:addSameType(tname, x + 2, y + 2)
	logic:addSameType(tname, x + 3, y + 0)
	logic:addSameType(tname, x + 4, y + 0)
	logic:addSameType(tname, x + 3, y + 1)
	logic:addSameType(tname, x + 4, y + 1)
end


--This function is called whenever the logic tile needs to draw a tile anywhere
function Eval(logic, info, u, d, l, r, ul, ur, dl, dr)
	--Logic is the actual logic object, it contains s_0, s_1, s_string and all the same type data.

	--The passed parameters u, d, l, r, ul, ur, dl, dr are boolean values which stand for
	--Up, Down, Left, Right, Up-Left, Up-Right, Down-Left, DownRight respectively.
	--These boolean values represent if one of those directions is of the same type of tile

	--The info object contains drawing data for this execution. We use the following method to adjust
	--The tile to draw here:
	--info:Adjust(tileset name, X tile, Y tile)

	--This is all you need to know. The rest you will need to learn LUA syntax and
	--Rely on your logic

	info:Adjust(tname, x + 1, y + 1)

	if not u then
		if not l then info:Adjust(tname, x, y)
		elseif not r then info:Adjust(tname, x + 2, y)
		else info:Adjust(tname, x + 1, y + (dl and 0 or ul and 2 or 0))
		end
	elseif not d then
		if not l then info:Adjust(tname, x, y + 2)
		elseif not r then info:Adjust(tname, x + 2, y + 2)
		else info:Adjust(tname, x + 1, y + 2)
		end
	elseif u then
		if not l then info:Adjust(tname, x, y + 1)
		elseif not r then info:Adjust(tname, x + 2, y + 1)
		end
	end

	if u and d and l and r then
		if not ul then info:Adjust(tname, x + 3, y)
		elseif not ur then info:Adjust(tname, x + 4, y)
		elseif not dl then info:Adjust(tname, x + 3, y + 1)
		elseif not dr then info:Adjust(tname, x + 4, y + 1)
		end
	end

	if u and d and l and r and ul and ur and dl and dr then
		info:Adjust(tname, x + 1, y + 1)
	end

end