import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

public class KeyHandler implements KeyListener {
	public KeyHandler(SnakeGame game) {
		game.addKeyListener(this);
	}

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

	public void keyReleased(KeyEvent e) {
	}

	public void keyTyped(KeyEvent e) {
	}
}
