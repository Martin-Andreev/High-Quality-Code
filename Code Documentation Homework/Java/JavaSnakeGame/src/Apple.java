import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;

/**
 * This class creates a red apple with random position and draws in on the screen.
 * @author Martin
 * Red apple with random position.
 */
public class Apple {
	public static Random randomGenerator;
	private Point applePoint;
	private Color appleColor;

	/**
	 * This is the constructor of the class Apple
	 * @param This is the snake object on which depends where the apple will be initialize (snake 
	 * body and new arrive apple cannot be on the same place)
	 */
	public Apple(Snake snake) {
		applePoint = createApple(snake);
		appleColor = Color.RED;
	}

	/**
	 * A method which creates new apple
	 * @param snake This is the snake which coordinates are taken
	 * @return New coordinate point where the new apple will be putted
	 */
	private Point createApple(Snake snake) {
		randomGenerator = new Random();
		int x = randomGenerator.nextInt(30) * 20;
		int y = randomGenerator.nextInt(30) * 20;
		for (Point snakePoint : snake.snakeBody) {
			if (x == snakePoint.getX() || y == snakePoint.getY()) {
				return createApple(snake);
			}
		}

		return new Point(x, y);
	}

	/**
	 * This method draws the apple.
	 * @param g This is the graphics of the game
	 */
	public void drawApple(Graphics g) {
		applePoint.draw(g, appleColor);
	}

	/**
	 * The getter of the point apple point
	 * @return the coordinate of the apple
	 */
	public Point getPoint() {
		return applePoint;
	}
}
