/*
this script is made to show you one way picking up items could possibly be done.
you can find others ways to do this but using the same techniques i do to add item :P.
*/

var inventoryIcon:Texture2D;//this is what will be displayed in the demos On Screen GUI.
var itemType:int; 
var isStackable=false;//If this is true it will be stacked in the inv. if not then it wont!
//Stacking will be added in the next update.
var maxStack=9;//each stack can be this big.


class Item {
	
	var mInventoryIcon:Texture2D;
	var mType:int;
	
	function UseItem() {
	
	}

}

class FoodItem extends Item {
	
	var healAmount:int;
	
	function FoodItem(inventoryIcon:Texture2D) {
		mInventoryIcon = inventoryIcon;
		mType = 1;
		healAmount = 10;
	}
	
	function UseItem() {
		Debug.Log("USED FOOD");
		var player = GameObject.FindWithTag("Player");
		
		if(player != null) {
			player.GetComponent("PlayerController").OnHeal(healAmount);
		}
	}
}

class HealthItem extends Item {
	
	function HealthItem(inventoryIcon:Texture2D) {
		mInventoryIcon = inventoryIcon;
		mType = 2;
	}
	
	function UseItem() {
		Debug.Log("USED HEALTH");
	}
}

class ChestplateItem extends Item {
	
	var defense:int = 3;
	
	function ChestplateItem(inventoryIcon:Texture2D) {
		mInventoryIcon = inventoryIcon;
		mType = 3;
	}
	
	function UseItem() {
		Debug.Log("USED Armor");

	}
}


function AddToInventory(){//When you click an item
	//im going to check if its collider is active. since i know i deactivate it when
//it gets picked up. BUT you could also make a var "canGet" or somthing and change it when its picked up and dropped.
//basically we dont want to pick up somthing, we already have.
		transform.collider.isTrigger=false;
		var playersinv=FindObjectOfType(Inventory);//finding the players inv. I suggest when making
		//a game, you make a function that picks up an item within the player script. and then have the inventory
		//referneced from its own variable. OR since the playerscript would be attached to the inv i suggest you
		//do GetComponent(Inventory).AddItem, This way multiple players can have inventorys.
		if(itemType == 1) {
			playersinv.AddItem(new FoodItem(inventoryIcon));
		} else if(itemType == 2) {
			playersinv.AddItem(new HealthItem(inventoryIcon));
		} else if(itemType == 3) {
			playersinv.AddItem(new ChestplateItem(inventoryIcon));
		}
	
}






function MoveMeToThePlayer(theplayer:Transform){//This will basically make the item stay where the player is
//as long as its in the players inventory. This can also be done multiple ways, but ill stick with an easy one.
	transform.collider.isTrigger=true;//makes it undence.
	transform.renderer.enabled=false;//makes it invisible
	transform.parent=theplayer;//makes the object parented to the player.
	transform.localPosition=Vector3.zero;//now that the item is parented to the player
	//i can set the localPosition to 0,0,0 and it will be ontop of the player. and move around with him/her
}





function BeDropped(){//This will drop the item wherever the player is.
	//since the player has the item parented to him, and at his position (locally) we are going to just 
	//drop the item where it already is
	transform.collider.isTrigger=false;//reactive its collider.
	transform.renderer.enabled=true;//allow it to be seen again.
	transform.parent=null;//give it no parent.
}


/*
Alternate ways to make objects stay with a player. is just move it to an
unused part of the map and deactivate it like i did. Its invisible so it will be unseen
and its untouchable :P.
If you are switching scenes. for world areas or somthing. you can keep inventory objects
alive by doing "DontDestroyOnLoad(this)". These are just some tips. Design however youd
like to :P.
*/