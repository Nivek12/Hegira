//*******************************************//
//***************Created by Eddy*************//
//******************************************//

var Contents:Item[];
//Although in the demo I am going to identify items as its own script *Item* I will still
//identify and add them by thier transform to allow more of a versitile of ways to program a game
//using this simple type of script :P.


function AddItem(item:Item){//Add an item to the inventory.
	var newContents=new Array(Contents);
	newContents.Add(item);
	Debug.Log(item.mType+" Has been added to inventroy");
	Contents=newContents.ToBuiltin(Item);
}
function RemoveItem(item:Item){//Removed an item from the inventory.
	var newContents=new Array(Contents);
	var index=0;
	var shouldend=false;
	for(var i:Item in newContents){
		if(i==item){
			Debug.Log(item.mType+" Has been removed from inventroy");
			newContents.RemoveAt(index);
			shouldend=true;
			//No need to continue running through the loop since we found our item.
		}
		index++;//keep track of what index the item is and remove it.
		if(shouldend){
			Contents=newContents.ToBuiltin(Item);
			return;
		}
	}
}



function DebugInfo(){  //A simple debug. Will tell you everything that is in the inventory.
	Debug.Log("Inventory Debug - Contents");
	items=0;
	for(var i:Item in Contents){
		items++;
		Debug.Log(i.name);
	}
	Debug.Log("Inventory contains "+items+" Item(s)");
}