using Godot;
using System;

public class HeldItem : Node2D
{
	Item item;
	Sprite icon;
	PlayerMoveScript player;
	
	public override void _Ready(){
		var playerNode = GetOwner();
		player = playerNode as PlayerMoveScript;
		item = null;
		var heldItem = GetNode("HeldItem");
		icon = heldItem as Sprite;
	}
	
	public override void _Process(float delta){
		if(item != null){
			// player is holding an item
			icon.SetTexture(item.GetSpriteTexture());
		} else {
			// player can interact with an item
		}
	}
}
