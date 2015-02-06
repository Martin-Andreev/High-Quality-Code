import java.awt.Color;
import java.awt.Graphics;
import java.util.LinkedList;

public class Snake {
	LinkedList<Point> snakeBody = new LinkedList<Point>();
	private Color snakeColor;
	private int velocityX, velocityY;

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

	public void drawSnake(Graphics g) {
		for (Point point : this.snakeBody) {
			point.draw(g, snakeColor);
		}
	}

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

	public int getVelocityX() {
		return velocityX;
	}

	public void setVelocityX(int velocityX) {
		this.velocityX = velocityX;
	}

	public int getVelocityY() {
		return velocityY;
	}

	public void setVelocityY(int velocityY) {
		this.velocityY = velocityY;
	}
}
