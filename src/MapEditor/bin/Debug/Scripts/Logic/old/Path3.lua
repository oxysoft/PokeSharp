function Load(logic)
	logic.name = "Path3"
	logic.s_0 = 0
	logic.s_1 = 53
	x = 0
	y = 3
	--classic 3x3 design
	logic:addSameType(0, x + 0, y + 0)
	logic:addSameType(0, x + 1, y + 0)
	logic:addSameType(0, x + 2, y + 0)
	logic:addSameType(0, x + 0, y + 1)
	logic:addSameType(0, x + 1, y + 1)
	logic:addSameType(0, x + 2, y + 1)
	logic:addSameType(0, x + 0, y + 2)
	logic:addSameType(0, x + 1, y + 2)
	logic:addSameType(0, x + 2, y + 2)

	--inner corners design
	logic:addSameType(0, x + 3, y + 0)
	logic:addSameType(0, x + 4, y + 0)
	logic:addSameType(0, x + 3, y + 1)
	logic:addSameType(0, x + 4, y + 1)
end

function Eval(logic, info, u, d, l, r, ul, ur, dl, dr)
	iu = u and 1 or 0
	id = d and 1 or 0
	il = l and 1 or 0
	ir = r and 1 or 0
	iul = ul and 1 or 0
	iur = ur and 1 or 0
	idl = dl and 1 or 0
	idr = dr and 1 or 0

	--println("u: " .. iu .. ", d: " .. id .. ", l: " .. il .. ", r: " .. ir  .. ", ul: " .. iul .. ", ur: " .. iur .. ", dl: " .. idl .. ", dr: " .. idr);

	x = 0
	y = 3

	info:Adjust(0, x + 1, y + 1)

	if not u then
		if not l then info:Adjust(0, x, y)
		elseif not r then info:Adjust(0, x + 2, y)
		else info:Adjust(0, x + 1, y + (dl and 0 or ul and 2 or 0))
		end
	elseif not d then
		if not l then info:Adjust(0, x, y + 2)
		elseif not r then info:Adjust(0, x + 2, y + 2)
		else info:Adjust(0, x + 1, y + 2)
		end
	elseif u then
		if not l then info:Adjust(0, x, y + 1)
		elseif not r then info:Adjust(0, x + 2, y + 1)
		end
	end

	if u and d and l and r then
		if not ul then info:Adjust(0, x + 3, y)
		elseif not ur then info:Adjust(0, x + 4, y)
		elseif not dl then info:Adjust(0, x + 3, y + 1)
		elseif not dr then info:Adjust(0, x + 4, y + 1)
		end
	end

	if u and d and l and r and ul and ur and dl and dr then
		info:Adjust(0, x + 1, y + 1)
	end

end