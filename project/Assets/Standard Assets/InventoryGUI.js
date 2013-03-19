//This type of inventory display will be a bag. similair to WoW.
var backDrop:Texture2D;
var windowPosition:Vector2=Vector2(200,200);//where on the screen the window will appear.
//this can easily be and should be updated on the fly incase the screen size changes or what not.
var windowSize:Vector2=Vector2(300.0,300.0);//the size of the window the bag will be displayed.
var itemIconSize:Vector2=Vector2(32.0,32.0);//The size of the item icons
var updateListDelay=0.0;//This will be used to updated the inventory on screen, rather then
//updating it every time OnGUI is called. if you prefer you can directly get what in the list. but i
//dont like having multiple GetComponents >.<.
var lastUpdate=0.0;//last time we updated the display.
var UpdatedList:Item[];
var associatedInventory:Inventory;



var showInventory : boolean = false;

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
		GUI.DrawTexture(Rect(windowPosition.x + 300,windowPosition.y,windowSize.x,windowSize.y),backDrop,ScaleMode.StretchToFill);
		
		//If there is an something equiped in armor, then show it. 
		if(GUI.Button(Rect(windowPosition.x + 332 ,windowPosition.y,itemIconSize.x,itemIconSize.y), UpdatedList[0].mInventoryIcon)) {
		
		}
		
		
	}
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