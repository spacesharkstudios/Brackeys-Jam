using Godot;
using System;

public class Item : Node
{
	Texture icon;
	Sprite itemSprite;
	public float interactRadius;
	
	public override void _Ready(){
		itemSprite = GetSpriteNode("Sprite");
		icon = itemSprite.GetTexture();
	}
	
	public Texture GetSpriteTexture(){
		return icon;
	}
	
	public Item GetItem(){
		return this;
	}
	
	// return the sprite node with the passed in node name
	private Sprite GetSpriteNode(string nodeName){
		var spriteNode = GetNode(nodeName);
		return spriteNode as Sprite;
	}
}
