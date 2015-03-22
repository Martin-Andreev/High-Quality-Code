import java.awt.Color;
import java.awt.Graphics;
import java.util.LinkedList;

public class Snake {
	LinkedList<Point> snakeBody = new LinkedList<Point>();
	private Color snakeColor;
	private int velocityX, velocityY;

	/**
	 * Makes new green snake body with defined body size put on defined position
	 */
	public Snake() {
		snakeColor = Color.GREEN;
		snakeBody.add(new Point(300, 100));
		snakeBody.add(new Point(280, 100));
		snakeBody.add(new Point(260, 100));
		snakeBody.add(new Point(240, 100));
		snakeBody.add(new Point(220, 100));
		snakeBody.add(new Point(200, 100));
		snakeBody.add(new Point(180, 100));
		snakeBody.add(new Point(160, 100));
		snakeBody.add(new Point(140, 100));
		snakeBody.add(new Point(120, 100));

		velocityX = 20;
		velocityY = 0;
	}

	/**
	 * Draws the snake on the screen
	 * @param g the initialization of an object from Graphic class
	 */
	public void drawSnake(Graphics g) {
		for (Point point : this.snakeBody) {
			point.draw(g, snakeColor);
		}
	}

	/**
	 * This method detects if a collision occurs between the snake body and the game borders,
	 * if the snake eats an apple, if the snake eats itself for the snake movement
	 */
	public void tick() {
		Point newPointPosition = new Point(
				(snakeBody.get(0).getX() + velocityX),
				(snakeBody.get(0).getY() + velocityY));
		if (newPointPosition.getX() > SnakeGame.WIDTH - 20) {
			SnakeGame.gameRunning = false;
		} else if (newPointPosition.getX() < 0) {
			SnakeGame.gameRunning = false;
		} else if (newPointPosition.getY() < 0) {
			SnakeGame.gameRunning = false;
		} else if (newPointPosition.getY() > SnakeGame.HEIGHT - 20) {
			SnakeGame.gameRunning = false;
		} else if (SnakeGame.apple.getPoint().equals(newPointPosition)) {
			snakeBody.add(SnakeGame.apple.getPoint());
			SnakeGame.apple = new Apple(this);
			SnakeGame.gamePoints += 50;
		} else if (snakeBody.contains(newPointPosition)) {
			SnakeGame.gameRunning = false;
			System.out.println("You ate yourself!");
		}

		for (int currentSnakeBody = snakeBody.size() - 1; currentSnakeBody > 0; currentSnakeBody--) {
			snakeBody.set(currentSnakeBody, new Point(snakeBody.get(currentSnakeBody - 1)));
		}

		snakeBody.set(0, newPointPosition);
	}

	/**
	 * This the getter of the horizontal velocity property
	 * @return the value of the horizontal velocity
	 */
	public int getVelocityX() {
		return velocityX;
	}

	/**
	 * This the setter of the horizontal velocity property
	 * @param velocityX the velocity to be set
	 */
	public void setVelocityX(int velocityX) {
		this.velocityX = velocityX;
	}

	/**
	 * This the getter of the vertical velocity property
	 * @return the value of the vertical velocity
	 */
	public int getVelocityY() {
		return velocityY;
	}

	/**
	 * This the setter of the horizontal velocity property
	 * @param velocityY the velocity to be set
	 */
	public void setVelocityY(int velocityY) {
		this.velocityY = velocityY;
	}
}
