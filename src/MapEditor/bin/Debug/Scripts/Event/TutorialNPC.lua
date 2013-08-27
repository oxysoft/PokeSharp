--[[

functions:
	OnInitialize(eventinfo, map, player) //when player enter map
	OnExecute(eventinfo, map, player) //when event is first ran
	OnDo(eventinfo, map, player) //during event being ran

objects:
	EventInfo
		- variables:
			status
			data1 //last yes/no result: nothing -> -1, no -> 0, yes -> 1
			data2 //last selection index selected result
			data3 //unk
		- methods:
			v ---- these methods advance the status when sent, only call one of them per OnExecute
			SendText(string)
			SendYesNo(string)
			SendSelection(string, arguments...)
			v ---- these methods do not advance the status, you can use them as much as you wish
			EndEvent()
	PlayerEntity
		- variables:
		- methods:
	Map
		- variables:
		- methods:

		]]

function OnInitialize(eventinfo, map, player)
end

function OnExecute(eventinfo, map, player)
end


function OnDo(eventinfo, map, player)
end