using Godot;
using System;

public class PlayerMoveScript : KinematicBody2D
{
	public int playerNum = -1;
	float hmove;
	float vmove;
	bool interact;
	float moveSpeed = 75f;
	Vector2 velocity;
	public bool facingRight;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		facingRight = false;
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

	public override void _PhysicsProcess(float delta){
		GetInput(playerNum); // adjust the player speed based on their input
		var collision = MoveAndCollide(velocity * delta * moveSpeed);
		if(collision != null){
			// special collision conditions
			// bounce off of other players
		}
		if(facingRight && velocity.x < 0){
			Flip();
		} else if(!facingRight && velocity.x > 0){
			Flip();
		}
	}

	// filter controller inputs by playernum
	// -1 = keyboard
	// 0 = controller 1
	// 1 = controller 2
	// 2 = controller 3
	// 3 = controller 4
	void GetInput(int playerNum){
		switch(playerNum){ // get the player input
			case -1: // keyboard input
				var  left = Input.IsActionPressed("ui_left");
				var right = Input.IsActionPressed("ui_right");
				var    up = Input.IsActionPressed("ui_up");
				var  down = Input.IsActionPressed("ui_down");
				
				int leftMove = 0;
				int rightMove = 0;
				int upMove = 0;
				int downMove = 0;
				if(left) leftMove = 1;
				if(right) rightMove = 1;
				if(up) upMove = 1;
				if(down) downMove = 1;
				
				vmove = downMove - upMove;
				hmove = rightMove - leftMove;
				
				velocity.x = hmove; velocity.y = vmove;
				velocity = velocity.Normalized();
				break;
			case 0: // controller 1 input
				hmove = Input.GetActionStrength("gp0_right") - Input.GetActionStrength("gp0_left");
				vmove = Input.GetActionStrength("gp0_down") - Input.GetActionStrength("gp0_up");
				velocity.x = hmove; velocity.y = vmove;
				break;
			case 1: // controller 2 input
				hmove = Input.GetActionStrength("gp1_right") - Input.GetActionStrength("gp1_left");
				vmove = Input.GetActionStrength("gp1_down") - Input.GetActionStrength("gp1_up");
				velocity.x = hmove; velocity.y = vmove;
				break;
			case 2: // controller 3 input
				hmove = Input.GetActionStrength("gp2_right") - Input.GetActionStrength("gp2_left");
				vmove = Input.GetActionStrength("gp2_down") - Input.GetActionStrength("gp2_up");
				velocity.x = hmove; velocity.y = vmove;
				break;
			case 3: // controller 4 input
				hmove = Input.GetActionStrength("gp3_right") - Input.GetActionStrength("gp3_left");
				vmove = Input.GetActionStrength("gp3_down") - Input.GetActionStrength("gp3_up");
				velocity.x = hmove; velocity.y = vmove;
				break;
		}
	}
	
	public Vector2 GetVelocity(){
		return velocity;
	}
	
	public void Flip(){
		if(!facingRight)
			this.SetScale(new Vector2(-1, 1));
		else
			this.SetScale(new Vector2(-1, -1));
		
		facingRight = !facingRight;
	}
}
