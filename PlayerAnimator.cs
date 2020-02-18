using Godot;
using System;

public class PlayerAnimator : AnimationPlayer
{
	public string _idleEmpty, _runEmpty, _itemPickup, _idleHolding, _runHolding;
	Animation idleEmpty, runEmpty, itemPickup, idleHolding, runHolding, test;
	PlayerMoveScript player;
	Vector2 playerMove;
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		var playerNode = GetOwner();
		if(playerNode != null){
			player = playerNode as PlayerMoveScript;
		}
		
		_idleEmpty = "Player_Idle_EmptyHand";
		_runEmpty = "Player_Jog_EmptyHand";
		_itemPickup = "Player_ItemPickup";
		_idleHolding = "Player_Idle_HoldingItem";
		_runHolding = "Player_Jog_HoldingItem";
	}

  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta) {
		playerMove = player.GetVelocity();
		if(playerMove.LengthSquared() > 0){
			// player is moving
			PlayAnimation(_runEmpty);
		} else {
			// player is standing still
			PlayAnimation(_idleEmpty);
		}
	}

	public void PlayAnimation(string animName) {
		// stop playing the previous animation
		Play(animName);
	}
}
