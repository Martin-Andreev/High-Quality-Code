import java.applet.Applet;
import java.awt.Dimension;
import java.awt.Graphics;

/**
 * This class makes new snake game with set graphics
 * @author Martin
 * Snake screen with set sizes
 */
@SuppressWarnings("serial")
public class GameApplet extends Applet {
	private SnakeGame game;
	KeyHandler keyHandler;

	/**
	 * Makes new game with set graphics options and key listener for snake movement
	 */
	public void init() {
		game = new SnakeGame();
		game.setPreferredSize(new Dimension(800, 650));
		game.setVisible(true);
		game.setFocusable(true);
		this.add(game);
		this.setVisible(true);
		this.setSize(new Dimension(800, 650));
		keyHandler = new KeyHandler(game);
	}

	/**
	 * Makes screen size of the game
	 */
	public void paint(Graphics g) {
		this.setSize(new Dimension(800, 650));
	}
}
