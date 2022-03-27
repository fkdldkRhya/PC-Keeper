import java.io.*;
import java.net.*;
import java.util.*;
import java.util.concurrent.Callable;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class ServerClass {
	
	public static Socket connection;
	public final static int PORT = 25565;
	public static void main(String[] args) {
		ExecutorService pool = Executors.newFixedThreadPool(50);
		try(ServerSocket server = new ServerSocket(PORT)){
			System.out.println("Server Start!");
			while(true){
				try{
					connection = server.accept();
					System.out.println("newc");
					Callable<Void> task = new DaytimeTask(connection);
					InputStream is = connection.getInputStream();
					InputStreamReader isr = new InputStreamReader(is);
	                BufferedReader br = new BufferedReader(isr);
	                String line = br.readLine();
	                System.out.println(line);
					pool.submit(task);
				}catch(IOException e){}
			}
		}catch(IOException e){
			System.err.println("스타트 서버에 연결할 수 없습니다.");
		}
	}

	private static class DaytimeTask implements Callable<Void> {
		private Socket connection;
		DaytimeTask(Socket connection) {
			this.connection= connection;
		}
		public Void call(){
			try{
				Writer out = new OutputStreamWriter(connection.getOutputStream());
				Date now = new Date();
				out.write(now.toString() + "\r\n");
				out.flush();
			
			}catch(IOException e){
				System.err.println(e);
			}finally{
				try{
					connection.close();
				}catch(IOException e){}
			}
			return null;
		}
	}
}
