import java.awt.Canvas;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.image.BufferedImage;

/**
 * This class creates the graphics of the game and it's size
 * @author Martin
 * Game screen
 */
@SuppressWarnings("serial")
public class SnakeGame extends Canvas implements Runnable {
	public static final int WIDTH = 600;
	public static final int HEIGHT = 600;
	private final Dimension dimension = new Dimension(WIDTH, HEIGHT);
	public static Snake snake;
	public static Apple apple;
	static boolean gameRunning = false;
	static int gamePoints;
	private Graphics globalGraphics;
	private Thread runThread;	
	
	/**
	 * Make new objects of type snake and type apple.
	 */
	public SnakeGame() {	
		snake = new Snake();
		apple = new Apple(snake);
	}
	
	/**
	 * This methods set screen dimension and makes global graphics
	 */
	public void paint(Graphics g){
		this.setPreferredSize(dimension);
		globalGraphics = g.create();
		gamePoints = 0;
		
		if (runThread == null) {
			runThread = new Thread(this);
			runThread.start();
			gameRunning = true;
		}
	}
	
	/**
	 * This is the main loop of the game
	 */
	public void run(){
		while(gameRunning){
			snake.tick();
			render(globalGraphics);
			try {
				Thread.sleep(100);
			} catch (Exception e) {
				// TODO:
			}
		}
	}
		
	/**
	 * This methods draws the snake and the apple on the screen
	 * @param g instantiate object of the class Graphics
	 */
	public void render(Graphics g){
		g.clearRect(0, 0, WIDTH, HEIGHT + 25);
		g.drawRect(0, 0, WIDTH, HEIGHT);			
		snake.drawSnake(g);
		apple.drawApple(g);
		g.drawString("score = " + gamePoints, 10, HEIGHT + 25);		
	}
}