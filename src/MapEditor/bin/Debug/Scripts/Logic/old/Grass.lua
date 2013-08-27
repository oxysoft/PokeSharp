function Load(logic)
	logic.name = "Grass"
	logic.s_0 = 0
	logic.s_1 = 10

	logic:addSameType(0, 0, 19)
end

function Eval(logic, info, u, d, l, r, ul, ur, dl, dr)
	info:Adjust(0, 10, 0)
	r = math.random(0, 25)

	if (r == 0) then
		sprites = {}
		sprites[0] = 10
		sprites[1] = 11
		sprites[2] = 12
		sprites[3] = 23
		sprites[4] = 24
		sprites[5] = 25
		sprites[6] = 38
		sprites[7] = 62
		sprites[8] = 63
		sprites[9] = 64
		sprites[10] = 62 + 13
		sprites[11] = 63 + 13
		sprites[12] = 64 + 13
		sprites[13] = 62 + 26
		sprites[14] = 63 + 26
		sprites[15] = 64 + 26
		sprites[16] = 62 + 39
		sprites[17] = 63 + 39
		sprites[18] = 64 + 39
		info:Adjust(0, sprites[math.random(0, table.getn(sprites)) - 1])
	end

end