
import java.awt.Color;
import java.awt.FlowLayout;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;
import java.io.FileNotFoundException;
import java.util.Random;
import java.util.Scanner;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPasswordField;
import javax.swing.JTextField;
import javax.swing.ProgressMonitor;
import javax.swing.SwingConstants;
import javax.swing.SwingUtilities;
import javax.swing.Timer;
import javax.swing.UIManager;

@SuppressWarnings("serial")
public class C extends JFrame implements ActionListener {
	public static int LoginInt = 0;
	public static ProgressMonitor pbar;
	public static int counter = 0;
	public static int UpDateProgressbar = 0;
	public static Random random = new Random();
	public static Timer timer;
	public static String LoginPath = "C:\\Users\\user\\Desktop\\Sihun\\A\\LD";
	public static JLabel INFmsg = new JLabel("",SwingConstants.RIGHT);
	public static JFrame jf = new JFrame();
	
	public C() {
		super("<__LOGIN__>__Client");
	    setSize(250, 100);
	    setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	    pbar = new ProgressMonitor(null, "Reading client data file ...",
	        "Initializing . . .", 0, 200);
	    timer = new Timer(500, this);
	    timer.start();
	    setVisible(false);
	  }
	
	public void actionPerformed(ActionEvent e) {SwingUtilities.invokeLater(new Update()); }

	  class Update implements Runnable {
	    public void run() {
	      for(int i=0; i<999; i++) {
	    	  UpDateProgressbar = random.nextInt(20);
	    	  if(!(UpDateProgressbar == 0)) {
	    		  break;
	    	  } i = 0;
	      }
	      pbar.setProgress(counter);
	      pbar.setNote("Operation is " + counter + "% complete");
	      counter += random.nextInt(35);
	    	if(counter > 100) {
	    		try {Thread.sleep(1000);} catch (InterruptedException e) {e.printStackTrace();}
				 pbar.close();
				 timer.stop();
				 LoginGUI();
		  }
	    }
	  }
	
	public static void LoginMC(String pass,String ID,String IDPFilePath) {
		File file1 = new File(IDPFilePath+"\\"+ID+".txt");
		try {
			if(file1.exists()) {
				Scanner sc1 = new Scanner(file1);
				while(sc1.hasNextLine()) {
					String Line = sc1.nextLine();
					if(Line.equals(pass)) {
						LoginSAF(1);
					}else {
						LoginSAF(0);
					}
				}
				sc1.close();
			}else {
				LoginSAF(0);
			}
		} catch (FileNotFoundException e) {e.printStackTrace();}
	}
	
	public static void LoginSAF(int check) {
		if(check == 1) {
			INFmsg.setForeground(Color.green);
			INFmsg.setText("Verifying sign in ...");
			INFmsg.setText(String.format("<html>%s<font color=#4AC117>%s</font></html>", 
					"", INFmsg.getText()));
			jf.dispose();
		}else {
			INFmsg.setForeground(Color.RED);
			INFmsg.setText("ID or password do not match.");
		}
	}
	
	public static void LoginGUI() {
		JTextField ID = new JTextField(20);
		JPasswordField PASS = new JPasswordField(20);
		JLabel IDLABEL = new JLabel("   ID    ",SwingConstants.RIGHT);
		JLabel info = new JLabel("Version: "+" PUBLIC_<__LOGIN__>_Client",SwingConstants.RIGHT);
		info.setFont(new Font("Serif", Font.PLAIN, 9));;
		JLabel PASSLABEL = new JLabel("  PW  ");
		JButton jb = new JButton("Login");
		jf.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		jf.setTitle("<__LOGIN__>__Client");
		//jf.getRootPane().setWindowDecorationStyle(JRootPane.QUESTION_DIALOG);
		//jf.setUndecorated(true); 
		jf.setLocationRelativeTo(null);
		jf.setResizable(false);
		jf.setVisible(true);
		jf.setSize(300,160);
		jf.setLayout(new FlowLayout());
		jf.add(IDLABEL);
		jf.add(ID);
		jf.add(PASSLABEL);
		jf.add(PASS);
		jf.add(INFmsg);
		jf.add(jb);
		jf.add(info);
		jf.setLocationRelativeTo(null);
		INFmsg.setForeground(Color.BLUE);
		INFmsg.setText("Please enter ID and Password");
		ID.addActionListener(new ActionListener() {
			@SuppressWarnings("deprecation")
			public void actionPerformed(ActionEvent e) {
				if(!PASS.getText().toString().equals("")||PASS.getText().toString().equals(null)||ID.getText().toString().equals("")||ID.getText().toString().equals(null)) {
					LoginMC( PASS.getText().toString(),ID.getText().toString(),LoginPath);	
				}else {
					INFmsg.setForeground(Color.RED);
					INFmsg.setText("ID or password do not match.");
				}
			}
		});
		PASS.addActionListener(new ActionListener() {
			@SuppressWarnings("deprecation")
			public void actionPerformed(ActionEvent e) {
				if(!PASS.getText().toString().equals("")||PASS.getText().toString().equals(null)||ID.getText().toString().equals("")||ID.getText().toString().equals(null)) {
					LoginMC( PASS.getText().toString(),ID.getText().toString(),LoginPath);	
				}else {
					INFmsg.setForeground(Color.RED);
					INFmsg.setText("ID or password do not match.");
				}
			}
		});
		jb.addActionListener(new ActionListener() {
			@SuppressWarnings("deprecation")
			public void actionPerformed(ActionEvent e) {
				if(!PASS.getText().toString().equals("")||PASS.getText().toString().equals(null)||ID.getText().toString().equals("")||ID.getText().toString().equals(null)) {
					LoginMC( PASS.getText().toString(),ID.getText().toString(),LoginPath);	
				}else {
					INFmsg.setForeground(Color.RED);
					INFmsg.setText("ID or password do not match.");
				}
			}
		});
	}
	
	public static void serverClientDataReadProgressbar() {
	    UIManager.put("ProgressMonitor.progressText", "<__LOGIN__>__Client");
	    UIManager.put("OptionPane.cancelButtonText", "Go Away");
	    new C();
	}
	
	public static void serverClientDataRead() {

	}
	
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		serverClientDataReadProgressbar();

	}
}
