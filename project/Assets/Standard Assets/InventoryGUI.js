//hacked in weapon icon
var weaponIcon:Texture2D;

//This type of inventory display will be a bag. similair to WoW.
var backDrop:Texture2D;
var equipTexture:Texture2D;

var windowPosition:Vector2=Vector2(200,200);//where on the screen the window will appear.
//this can easily be and should be updated on the fly incase the screen size changes or what not.
var windowSize:Vector2=Vector2(600.0,800.0);//the size of the window the bag will be displayed.
var itemIconSize:Vector2=Vector2(32.0,32.0);//The size of the item icons
var updateListDelay=0.0;//This will be used to updated the inventory on screen, rather then
//updating it every time OnGUI is called. if you prefer you can directly get what in the list. but i
//dont like having multiple GetComponents >.<.
var lastUpdate=0.0;//last time we updated the display.
var UpdatedList:Item[];
var associatedInventory:Inventory;

//Player equip window variables
var currentArmour:Item;
var currentWeapon:Item;

var showInventory : boolean = false;


function Start() {
	currentArmour = null;
	currentWeapon = null;
}

function UpdateInventoryList(){
	UpdatedList=associatedInventory.Contents;
}
function OnGUI(){
	//THIS BLOCK OF CODE IS JUST FOR PEOPLE TO MOVE THE BOX AROUND.
	//If your making a game you dont need anything this this.
	windowPosition.x = int.Parse(GUI.TextField(Rect (100, 10, 40, 20), ""+windowPosition.x, 3));
	windowPosition.y = int.Parse(GUI.TextField(Rect (100, 30, 40, 20), ""+windowPosition.y, 3));
	windowSize.x = int.Parse(GUI.TextField(Rect (100, 50, 40, 20), ""+windowSize.x, 3));
	windowSize.y = int.Parse(GUI.TextField(Rect (100, 70, 40, 20), ""+windowSize.y, 3));
	itemIconSize.x = int.Parse(GUI.TextField(Rect (100, 90, 40, 20), ""+itemIconSize.x, 3));
	itemIconSize.y = int.Parse(GUI.TextField(Rect (100, 110, 40, 20), ""+itemIconSize.y, 3));
	
	GUI.Label(Rect (0, 10, 400, 20), "WindowPosition X:");
	GUI.Label(Rect (0, 30, 400, 20), "WindowPosition Y");
	GUI.Label(Rect (0, 50, 400, 20), "WindowSize X");
	GUI.Label(Rect (0, 70, 400, 20), "WindowSize Y");
	GUI.Label(Rect (0, 90, 400, 20), "ItemIconSize X");
	GUI.Label(Rect (0, 110, 400, 20), "ItemIconSize Y");
	//THIS IS WHERE THE EDITING STUFF ENDS> FROM HERE BEFORE YOU would need.
	
	var currentX=windowPosition.x;//where to put the first items
	var currentY=windowPosition.y;
	
	if(showInventory) {
		//Draw the backdrop in the windowposition and the size of the windowsize.
		GUI.DrawTexture(Rect(windowPosition.x,windowPosition.y,windowSize.x,windowSize.y),backDrop,ScaleMode.StretchToFill);
		for(var i:Item in UpdatedList){//we start a loop for whats in our list.

			if(GUI.Button(Rect(currentX,currentY,itemIconSize.x,itemIconSize.y), i.mInventoryIcon)){
			    i.UseItem();
				associatedInventory.RemoveItem(i);//Remove the item from the list.
				lastUpdate=0.0;//Set the lastupdate to 0 to allow the list to update.
				
				//In case the item is an armour piece, display it in the player equip window
				if(i.mType == 3) {
					SwapArmour(i);
				}
				
				//If the item is a weapon, then equip it
				if(i.mType == 4) {
					SwapWeapon(i);
				}
			}
			currentX+=itemIconSize.x;
			if(currentX+itemIconSize.x>windowPosition.x+windowSize.x){
			//if the next item icon will be to large for the window.....
				currentX=windowPosition.x;//we move it back to its startpoint
				currentY+=itemIconSize.y;//and down a row.
				if(currentY+itemIconSize.y>windowPosition.y+windowSize.y){//if the row is down to far. we quit the loop
					return;
				}
			}
		}
		
		//Set up the player equip window
		GUI.DrawTexture(Rect(windowPosition.x + 300,windowPosition.y,windowSize.x,windowSize.y),equipTexture,ScaleMode.StretchToFill);
		
		//If there is an something equiped in armor, then show it. 
		if(currentArmour != null) {
			if(GUI.Button(Rect(windowPosition.x + 362 ,windowPosition.y + 53,itemIconSize.x,itemIconSize.y), currentArmour.mInventoryIcon)) {
				UnequipArmour();
			}
		
		}
		
		//If a weapon is equipped, show it
		if(true) {
			
			//For now let's just make the weapon a hacked in necessary unequippable thing
			GUI.Button(Rect(windowPosition.x + 305 ,windowPosition.y + 87,itemIconSize.x,itemIconSize.y), weaponIcon);
		}
	}
}

function SwapArmour(newArmour:Item) {
	var temp:Item = currentArmour;
	currentArmour = newArmour;
	
	GetComponent("PlayerController").SetDefense(currentArmour.defense);
							
    if(temp != null) {
 	   associatedInventory.AddItem(temp);
    } 
}

function SwapWeapon(newWeapon:Item) {
	var temp:Item = currentWeapon;
	currentWeapon = newWeapon;
	
	GetComponent("PlayerController").SetAttack(currentWeapon.attack);
	
	if(temp != null) {
 	   associatedInventory.AddItem(temp);
    }
	
}

function UnequipArmour() {

	//Add the armour back into invenotry and unequip it
	associatedInventory.AddItem(currentArmour);
	currentArmour = null;
	GetComponent("PlayerController").SetDefense(0);
}

function FixedUpdate(){//I will update the display inventory here.
	if(Time.time>lastUpdate){
		lastUpdate=Time.time+updateListDelay;
		UpdateInventoryList();
	}
}

function ShowInventory() {
	showInventory = true;
}

function CloseInventory() {
	showInventory = false;
}