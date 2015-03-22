import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

/**
 * A class which checks for pressed keys
 * @author Martin
 *Key code of the pressed key
 */
public class KeyHandler implements KeyListener {
	/**
	 * This method adds key listener for the game which will check if define key is pressed
	 * @param game this is the game which will have key listener
	 */
	public KeyHandler(SnakeGame game) {
		game.addKeyListener(this);
	}

	/**
	 * This method checks if a define key is pressed
	 */
	public void keyPressed(KeyEvent e) {
		int keyCode = e.getKeyCode();
		if (keyCode == KeyEvent.VK_W || keyCode == KeyEvent.VK_UP) {
			if (SnakeGame.snake.getVelocityY() != 20) {
				SnakeGame.snake.setVelocityX(0);
				SnakeGame.snake.setVelocityY(-20);
			}
		}

		if (keyCode == KeyEvent.VK_S || keyCode == KeyEvent.VK_DOWN) {
			if (SnakeGame.snake.getVelocityY() != -20) {
				SnakeGame.snake.setVelocityX(0);
				SnakeGame.snake.setVelocityY(20);
			}
		}

		if (keyCode == KeyEvent.VK_D || keyCode == KeyEvent.VK_RIGHT) {
			if (SnakeGame.snake.getVelocityX() != -20) {
				SnakeGame.snake.setVelocityX(20);
				SnakeGame.snake.setVelocityY(0);
			}
		}

		if (keyCode == KeyEvent.VK_A || keyCode == KeyEvent.VK_LEFT) {
			if (SnakeGame.snake.getVelocityX() != 20) {
				SnakeGame.snake.setVelocityX(-20);
				SnakeGame.snake.setVelocityY(0);
			}
		}

		if (keyCode == KeyEvent.VK_ESCAPE) {
			System.exit(0);
		}
	}

	/**
	 * Indicates if the pressed button is released
	 */
	public void keyReleased(KeyEvent e) {
	}

	/**
	 * This method is invoked when a key has been typed
	 */
	public void keyTyped(KeyEvent e) {
	}
}
