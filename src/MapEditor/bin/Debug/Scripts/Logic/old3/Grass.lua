tname = "HGSS_Outdoor"
x = 0
y = 0

function Load(logic)
	logic.name = "Grass"

	logic.s_0 = tname
	logic.s_1 = 0

	logic:addSameType(tname, x, y)
	logic:addSameType(tname, x, y + 1)
	logic:addSameType(tname, x, y + 2)
	logic:addSameType(tname, x, y + 3)
	logic:addSameType(tname, x, y + 4)
end


function Eval(logic, info, u, d, l, r, ul, ur, dl, dr)
	info:Adjust(tname, x, y)

	--[[r = math.random(0, 25)

	if (r == 0) then
		sprites = {}
		sprites[0] = 12
		sprites[1] = 24
		sprites[2] = 36
		sprites[3] = 48

		info:Adjust(tname, sprites[math.random(0, table.getn(sprites)) - 1])
	end]]

end