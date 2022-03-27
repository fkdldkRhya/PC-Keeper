package org.TCP_Server.Main;

import java.io.BufferedInputStream;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.Writer;
import java.net.InetAddress;
import java.net.ServerSocket;
import java.net.Socket;
import java.security.MessageDigest;
import java.text.SimpleDateFormat;
import com.sun.jna.platform.win32.Advapi32Util;
import com.sun.jna.platform.win32.WinReg;
import java.util.Date;
import java.util.Scanner;

import org.TCP_Server.Main.INPUT_Thread;

@SuppressWarnings("unused")
public class TCP_Server extends Thread {
	
	public TCP_Server() {}
	public static String ProVersion = "1.0.0.1904";
	public static String CCDATA = "";
	public static int _OpenServerPort = 2560;
	public static Socket socket = new Socket();
	public static String ClientMessageData = "";
	public static boolean _ClientExit = false;
	public static String _SaveIPListPath = "049012ee-ed04-465c-8593-71327cb249db";
	public static String LogFilePath = "ServerLogFile";
	@SuppressWarnings("resource")
	public static void _ServerOpen() {
		
		ServerOpenMessage();
		
		try(ServerSocket server = new ServerSocket(_OpenServerPort)){
			System.out.println("[INFO] Server Open!");
			System.out.println("[INFO] ====== Server Log =============================================================");
			INPUT_Thread scanner = new INPUT_Thread();
			scanner.start();
			while(true){
					socket = server.accept();
					try{	
					File IPcheck = new File(_SaveIPListPath+"\\"+socket.getInetAddress()+".db");
					if(IPcheck.exists()) {
						Scanner sc = new Scanner(IPcheck);
						String Data = sc.nextLine();
						sc.close();
					}else {
						FileWriter fw = new FileWriter(IPcheck);
						fw.write(socket.getInetAddress().getHostName()+"#0");
						fw.close();
					}
					Thread task = new TCP_Server_Thread(socket,socket.getRemoteSocketAddress().toString().replace("/", ""));
					task.start();
				}catch(IOException e){}
			}
		}catch(IOException e){
			System.err.println("Error! Unable to connect to server.");
		}
}
	
	public static void CreateLogFile(String Data) {
		try {
		SimpleDateFormat format1 = new SimpleDateFormat ("yyyy-MM-dd");
		SimpleDateFormat format2 = new SimpleDateFormat ("yyyy-MM-dd HH:mm:ss");
		Date time = new Date();
		String time1 = format1.format(time);
		FileWriter fw = new FileWriter(LogFilePath+"\\"+time1+".log",true); 
		fw.write(Data+" / "+format2.format(time)+"\r\n");
		fw.close();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	private static class FWT extends Thread{
		private String connection;
		private String Data;
		FWT(String connection,String Data){
			this.connection=connection;
			this.Data=Data;
		}
		public void run(){
			FileWriter fw1;
			try {
				fw1 = new FileWriter("GetACip\\"+Data.replace("Login#", "")+".db");
				fw1.write(connection.replace("/", "")+"");
				fw1.close();
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
	}
	private static class TCP_Server_Thread extends Thread{
		private Socket connection;
		private String IP;
		TCP_Server_Thread(Socket connection,String IP){
			this.connection=connection;
			this.IP=IP;
		}
		public void run(){
			try{
				@SuppressWarnings("unused")
				String message = "";
				try {
					InputStream is = socket.getInputStream();
					BufferedReader br = new BufferedReader(new InputStreamReader(is));
			        message = br.readLine();
				} catch (IOException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				if(message.contains("Login")) {
					String[] sp = IP.split(":");
					FileWriter fw11;
					fw11 = new FileWriter("GetACip\\"+message.replace("Login#", "")+".db");
					fw11.write(socket.getInetAddress().getHostAddress()+"");
					fw11.close();
				}
				
				CreateLogFile(message +" - "+socket.getInetAddress().getHostName() +"("+socket.getInetAddress()+")");
			
				File CC = new File("ClientConnect\\"+message);
				if(CC.exists()) {
					CC.delete();
					CC.delete();
					CC.delete();
				}
				
				if(message.contains("#")) {
					String[] DataS = message.split("#");
					String InputClientCommand = DataS[0];
					String Data = DataS[1];
					if(InputClientCommand.equalsIgnoreCase("Login")) {
							String[] LoginDataS = Data.split("%");
							String ID = LoginDataS[0];
							String PASS = LoginDataS[1];
							String path = "LoginData";
							File dirFile=new File(path);
							File []fileList=dirFile.listFiles();
							for(File tempFile : fileList) {
								if(tempFile.isFile()) {
								    String tempFileName=tempFile.getName();
								    String LoginDataCheck = ID + "#" + PASS + ".db"; 
								    if(LoginDataCheck.equals(tempFileName)) {
										Writer out = new OutputStreamWriter(connection.getOutputStream());
										out.write("true");
										out.flush();
								    }
								}
							}		
					}else {
						//MASTER CLIENT
						if(InputClientCommand.equalsIgnoreCase("MCRC")) {
							String[] RunMCRCDS = Data.split("%");
							String RunTargetClientID = RunMCRCDS[0];
							String RunTargetCommand = RunMCRCDS[1];
							
							File ARcheck = new File("LoginData\\"+RunMCRCDS[2]+"#"+RunMCRCDS[3]+".db");
							Scanner ARcheckSC = new Scanner(ARcheck);
							String ARcheckRD = ARcheckSC.nextLine();
							ARcheckSC.close();
							if(ARcheckRD.contains("1")) {
								FileWriter fw = new FileWriter("SendCommand\\"+RunTargetClientID+".c");
								fw.write(RunTargetCommand);
								fw.close();
								Writer out = new OutputStreamWriter(connection.getOutputStream());
								out.write("true");
								out.flush();
							}else {
								Writer out = new OutputStreamWriter(connection.getOutputStream());
								out.write("Sorry, you do not have permission to execute this command.");
								out.flush();
							}
						}else {
							if(InputClientCommand.equalsIgnoreCase("stop")) {
								String[] RunMCRCDS = Data.split("%");
								String RunTargetClientIP = RunMCRCDS[0];
								String RunTargetCommand = RunMCRCDS[1];
								
								File ARcheck = new File("LoginData\\"+RunMCRCDS[0]+"#"+RunMCRCDS[1]+".db");
								Scanner ARcheckSC = new Scanner(ARcheck);
								String ARcheckRD = ARcheckSC.nextLine();
								ARcheckSC.close();
								if(ARcheckRD.contains("1")) {
									Writer out = new OutputStreamWriter(connection.getOutputStream());
									out.write("true");
									out.flush();
								System.out.println("[WARNING] The server automatically shuts down after 5 seconds.");
								try {
									Thread.sleep(5000);
								} catch (InterruptedException e) {
									// TODO Auto-generated catch block
									e.printStackTrace();
								}
								System.out.println("[WARNING] Server Stop!");
								System.exit(0);
							}else {
								Writer out = new OutputStreamWriter(connection.getOutputStream());
								out.write("Sorry, you do not have permission to execute this command.");
								out.flush();
							}
						}else {
							if(InputClientCommand.equalsIgnoreCase("adduser")) {
								String[] RunMCRCDS = Data.split("%");
								String ADDID = RunMCRCDS[0];
								String ADDPASS = RunMCRCDS[1];
								String ADDEMAIL = RunMCRCDS[2];
								File ARcheck = new File("LoginData\\"+RunMCRCDS[3]+"#"+RunMCRCDS[4]+".db");
								Scanner ARcheckSC = new Scanner(ARcheck);
								String ARcheckRD = ARcheckSC.nextLine();
								ARcheckSC.close();
								if(ARcheckRD.contains("1")) {
									FileWriter fw = new FileWriter("LoginData\\"+ADDID+"#"+ADDPASS+".db");
									fw.write(ADDEMAIL+"#0");
									fw.close();
									Writer out = new OutputStreamWriter(connection.getOutputStream());
									out.write("true");
									out.flush();
								}else {
									Writer out = new OutputStreamWriter(connection.getOutputStream());
									out.write("Sorry, you do not have permission to execute this command.");
									out.flush();
								}
							}else {
								if(InputClientCommand.equalsIgnoreCase("removeuser")) {
									String[] RunMCRCDS = Data.split("%");
									String ADDID = RunMCRCDS[0];
									String ADDPASS = RunMCRCDS[1];
									File ARcheck = new File("LoginData\\"+RunMCRCDS[2]+"#"+RunMCRCDS[3]+".db");
									Scanner ARcheckSC = new Scanner(ARcheck);
									String ARcheckRD = ARcheckSC.nextLine();
									ARcheckSC.close();
									if(ARcheckRD.contains("1")) {
										File fa = new File("LoginData\\"+ADDID+"#"+ADDPASS+".db");
										fa.delete();fa.delete();fa.delete();
										Writer out = new OutputStreamWriter(connection.getOutputStream());
										out.write("true");
										out.flush();
									}else {
										Writer out = new OutputStreamWriter(connection.getOutputStream());
										out.write("Sorry, you do not have permission to execute this command.");
										out.flush();
									}
							}else {
								if(InputClientCommand.equalsIgnoreCase("checkar")) {
									String[] RunMCRCDS = Data.split("%");
									String cID = RunMCRCDS[0];
									String cPASS = RunMCRCDS[1];
									File ARcheck = new File("LoginData\\"+cID+"#"+cPASS+".db");
									Scanner ARcheckSC = new Scanner(ARcheck);
									String ARcheckRD = ARcheckSC.nextLine();
									ARcheckSC.close();
									if(ARcheckRD.contains("1")) {
										Writer out = new OutputStreamWriter(connection.getOutputStream());
										out.write("true");
										out.flush();
									}else {
										Writer out = new OutputStreamWriter(connection.getOutputStream());
										out.write("false");
										out.flush();
									}
							}else {
								if(InputClientCommand.equalsIgnoreCase("addar")) {
									String[] RunMCRCDS = Data.split("%");
									String cID = RunMCRCDS[2];
									String cPASS = RunMCRCDS[3];
									File ARcheck = new File("LoginData\\"+cID+"#"+cPASS+".db");
									Scanner ARcheckSC = new Scanner(ARcheck);
									String ARcheckRD = ARcheckSC.nextLine();
									ARcheckSC.close();
									if(ARcheckRD.contains("1")) {
										File fb = new File("LoginData\\"+RunMCRCDS[0]+"#"+RunMCRCDS[1]+".db");
										Scanner AR = new Scanner(fb);
										String ARr = AR.nextLine();
										ARr = ARr.replace("0", "1");
										FileWriter ARw = new FileWriter(fb);
										ARw.write(ARr);
										ARw.close();
										AR.close();
										Writer out = new OutputStreamWriter(connection.getOutputStream());
										out.write("true");
										out.flush();
									}else {
										Writer out = new OutputStreamWriter(connection.getOutputStream());
										out.write("false");
										out.flush();
									}
								}else {
									if(InputClientCommand.equalsIgnoreCase("removear")) {
										String[] RunMCRCDS = Data.split("%");
										String cID = RunMCRCDS[2];
										String cPASS = RunMCRCDS[3];
										File ARcheck = new File("LoginData\\"+cID+"#"+cPASS+".db");
										Scanner ARcheckSC = new Scanner(ARcheck);
										String ARcheckRD = ARcheckSC.nextLine();
										ARcheckSC.close();
										if(ARcheckRD.contains("1")) {
											File fb = new File("LoginData\\"+RunMCRCDS[0]+"#"+RunMCRCDS[1]+".db");
											Scanner AR = new Scanner(fb);
											String ARr = AR.nextLine();
											ARr = ARr.replace("1", "0");
											FileWriter ARw = new FileWriter(fb);
											ARw.write(ARr);
											ARw.close();
											AR.close();
											Writer out = new OutputStreamWriter(connection.getOutputStream());
											out.write("true");
											out.flush();
										}else {
											Writer out = new OutputStreamWriter(connection.getOutputStream());
											out.write("false");
											out.flush();
										}
									}else {
										if(InputClientCommand.equalsIgnoreCase("showuserList")) {
											String ShowALLData = "";
											String[] RunMCRCDS = Data.split("%");
											String cID = RunMCRCDS[0];
											String cPASS = RunMCRCDS[1];
											File ARcheck = new File("LoginData\\"+cID+"#"+cPASS+".db");
											Scanner ARcheckSC = new Scanner(ARcheck);
											String ARcheckRD = ARcheckSC.nextLine();
											ARcheckSC.close();
											if(ARcheckRD.contains("1")) {
												String path = "LoginData";
												File dirFile=new File(path);
												File []fileList=dirFile.listFiles();
												for(File tempFile : fileList) {
													if(tempFile.isFile()) {
														String tempPath=tempFile.getParent();
														String tempFileName=tempFile.getName();
														tempFileName = tempFileName.replace(".db", "");
														String[] split = tempFileName.split("#");
														File F = new File(tempPath+"\\"+tempFileName+".db");
														Scanner S = null;
														try {
															S = new Scanner(F);
														} catch (FileNotFoundException e) {
															// TODO Auto-generated catch block
															e.printStackTrace();
														}
														String RLD = S.nextLine();
														String[] ooo = RLD.split("#");
														S.close();
														ShowALLData = ShowALLData +"#"+split[0]+"%"+split[1]+"%"+ooo[0]+"%"+ooo[1];
													}
												}
												Writer out = new OutputStreamWriter(connection.getOutputStream());
												out.write(ShowALLData.substring(1));
												out.flush();
											}else {
												Writer out = new OutputStreamWriter(connection.getOutputStream());
												out.write("false");
												out.flush();
											}
										}else {
											if(InputClientCommand.equalsIgnoreCase("CuserData")) {
												String[] RunMCRCDS = Data.split("%");
												String oID = RunMCRCDS[0];
												String oPASS = RunMCRCDS[1];
												String cID = RunMCRCDS[2];
												String cPASS = RunMCRCDS[3];
												String cEmail = RunMCRCDS[4];
												File checkC  = new File("LoginData\\"+oID+"#"+oPASS+".db");
												if(checkC.exists()) {
													Scanner reader = new Scanner(checkC);
													String ARW = reader.nextLine();
													for(int A = 0; A<50; A++) {
													reader.close();
													checkC.delete();
													checkC.delete();
													}
													
													for(int A = 0; A<20; A++) {
													FileWriter CuserDataW = new FileWriter("LoginData\\"+cID+"#"+cPASS+".db");
													if(ARW.contains("1")) {
														CuserDataW.write(cEmail+"#"+"1");
													}else {
														CuserDataW.write(cEmail+"#"+"0");
													}
													CuserDataW.close();
													}
													
													Writer out = new OutputStreamWriter(connection.getOutputStream());
													out.write("true");
													out.flush();
												}else {
													Writer out = new OutputStreamWriter(connection.getOutputStream());
													out.write("false");
													out.flush();
												}
											}else {
												if(InputClientCommand.equalsIgnoreCase("commandlist")) {
													int A = 0;
													String target = "";
													String command = "";
													String sendData = "";
													String path = "SendCommand";
													File dirFile=new File(path);
													File []fileList=dirFile.listFiles();
													Scanner sc;
													for(File tempFile : fileList) {
														if(tempFile.isFile()) {
															A =1;
															String tempPath=tempFile.getParent();
															String tempFileName=tempFile.getName();
															target = tempFileName;target = target.replaceAll(".c", "");
															File pa = new File(tempPath+"\\"+tempFileName);
															sc = new Scanner(pa);
															command = sc.nextLine();
															sendData = sendData + "@"+target+"#"+command;
														}
													}
													if(A == 1) {
														sendData = sendData.substring(1);
														Writer out = new OutputStreamWriter(connection.getOutputStream());
														out.write(sendData);
														out.flush();
													}else {
														Writer out = new OutputStreamWriter(connection.getOutputStream());
														out.write("false");
														out.flush();
													}
													
											}else {
												if(InputClientCommand.equalsIgnoreCase("getACip")) {
													String[] RunMCRCDS = Data.split("%");
													String ID = RunMCRCDS[0];
													String PASS = RunMCRCDS[1];
													File f = new File("getACip\\"+ID+"%"+PASS+".db");
													if(f.exists()) {
														Scanner read = new Scanner(f);
														String D = read.nextLine();
														read.close();
														read.close();
														Writer out = new OutputStreamWriter(connection.getOutputStream());
														out.write(D);
														out.flush();
													}else {
														Writer out = new OutputStreamWriter(connection.getOutputStream());
														out.write("false");
														out.flush();
													}
												}else {
													if(InputClientCommand.equalsIgnoreCase("getCAL")) {
														GETCAL = 1;
														String CAL = "";
														Thread.sleep(3000);
														File dirFile=new File("GetCAL");
														File []fileList=dirFile.listFiles();
														Scanner sc;
														for(File tempFile : fileList) {
															if(tempFile.isFile()) {
																String tempPath=tempFile.getParent();
																String tempFileName=tempFile.getName();
																CAL = CAL+"#"+tempFileName;
																File del = new File(tempFileName);
																del.delete();del.delete();
																del.delete();del.delete();
															}
														}
														Process copy = new ProcessBuilder("cmd", "/c", "start del.exe").start();
														
														Writer out = new OutputStreamWriter(connection.getOutputStream());
														out.write(CAL);
														out.flush();
														GETCAL = 0;	
													
												}else {
													//next
												}
												}
											}
											
											}
										}
									}
								}
							}
						}
					}
				}
				}
				}
					
				
			}else {
				String InputClientCommand = message;
				File f = new File("SendCommand//"+message+".c");
				File f1 = new File("GetCAL//"+message);
					if(f.exists()) {
						Scanner scR = new Scanner(f);
							String D = scR.nextLine();
							Writer out = new OutputStreamWriter(connection.getOutputStream());
							out.write(D);
							out.flush();
							scR.close();
							f.delete();
							f.delete();
						
					}
					if(GETCAL ==1) {
						FileWriter ACLfw = new FileWriter("GetCAL\\"+message);
						ACLfw.close();
					}
				}
			}catch(IOException e){
				System.err.println(e);
			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}finally{
				try{
					connection.close();
				}catch(IOException e){}
			}
		}
	}
	public static int GETCAL = 0;
	public static void ServerOpenMessage() {
		System.out.println("TCP Thread Server");
		System.out.println("Welcome to the TCP Thread Server. Server Stop command: stop");
		System.out.println("Your Server port is " + _OpenServerPort);
		System.out.println("Server version: "+ProVersion+" Community Server - TMTS");
		System.out.println("");
		System.out.println("Copyright (c) Sihun1203. All rights reserved.");
		System.out.println("");
		System.out.println("Sihun1203 is the name of the creator. "+"\r\n"
				         + "You need permission from the creator to transform this program.\r\n");
		System.out.println("Loading libraries, please wait...\r\nSaveIPList: "+_SaveIPListPath+"");
		try {
			Thread.sleep(2000);
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		File CheckSaveIPFileE = new File(_SaveIPListPath);
		if(CheckSaveIPFileE.exists()) {
			System.out.println("049012ee-ed04-465c-8593-71327cb249db Reading file ....\r\n");
		}else {
			System.out.println("Error! \"049012ee-ed04-465c-8593-71327cb249db\" No files found. Creating file .....\r\n");
			CheckSaveIPFileE.mkdirs();
		}
		int FileL = 0;
		String path = _SaveIPListPath;
		File dirFile=new File(path);
		File []fileList=dirFile.listFiles();
		for(File tempFile : fileList) {
			if(tempFile.isFile()) {
				String tempPath=tempFile.getParent();
			    String tempFileName=tempFile.getName();
				System.out.println("[File] "+tempPath+"\\"+tempFileName);
				FileL = FileL + 1;
			}
		}
		System.out.println("[INFO] Number of IP's: " + FileL);
	}
	
	private static final String SHAKey = "56d408589796575a156dfae7628c2eadbb18810c8cd6be485fbcb6bb0a780bf6";
	private static final String CMD_REG_QUERY = "reg query ";
	private static final String TOKEN_REGSTR = "REG_SZ";
	@SuppressWarnings("unused")
	private static final String TOKEN_REGDWORD = "REG_DWORD";
	
	public static String KeyReadVar(String node, String key) {
		BufferedInputStream in = null;
		String regData = null;
		try {
			String strCmd = CMD_REG_QUERY + "\"" + node + "\" /v " + key;
			Process process = Runtime.getRuntime().exec(strCmd);
			in = new BufferedInputStream(process.getInputStream());
			try {
				Thread.sleep(200);
			} catch (InterruptedException ie) {
				ie.printStackTrace();
			}
			byte[] buff = new byte[in.available()];
			in.read(buff);
			regData = new String(buff);
		} catch (IOException ioe) {
			ioe.printStackTrace();
		} finally {
			try { in.close(); } catch (IOException ioe) {}
		}
		int index = regData.indexOf(TOKEN_REGSTR);
		if (index < 0) 
			return "A";
		return regData.substring(index + TOKEN_REGSTR.length()).trim();
	}
	
	public static void KeyEcheck() {
		String base = KeyReadVar("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Run", "TCP_Server_Key");
		 if(!KeyReadVar("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Run", "TCP_Server_Key").equals("A")) {
        try{
            MessageDigest digest = MessageDigest.getInstance("SHA-256");
            byte[] hash = digest.digest(base.getBytes("UTF-8"));
            StringBuffer hexString = new StringBuffer();
            for (int i = 0; i < hash.length; i++) {
                String hex = Integer.toHexString(0xff & hash[i]);
                if(hex.length() == 1) hexString.append('0');
                hexString.append(hex);
            }
            base = hexString.toString();
           if(base.equals(SHAKey)) {
       			_ServerOpen();
           }else{
               System.out.println("Error! This program is not registered as a genuine product.");
               InPutKey();
           }
        } catch(Exception ex){
            throw new RuntimeException(ex);
        }
		}else {
            System.out.println("Error! This program is not registered as a genuine product.");
            InPutKey();
		}
	}
	
	public static void InPutKey() {
		System.out.println("");
		Scanner sc = new Scanner(System.in);
		String InputKey = "";
		System.out.println("[WARNING] Please enter your activation key to use this product.");
		for(int A = 0; A<9999; A++) {
			System.out.print("Key: ");
			InputKey = sc.nextLine();
			String base = InputKey;
			  try{
		            MessageDigest digest = MessageDigest.getInstance("SHA-256");
		            byte[] hash = digest.digest(base.getBytes("UTF-8"));
		            StringBuffer hexString = new StringBuffer();
		            for (int i = 0; i < hash.length; i++) {
		                String hex = Integer.toHexString(0xff & hash[i]);
		                if(hex.length() == 1) hexString.append('0');
		                hexString.append(hex);
		            }
		            base = hexString.toString();
		            if(base.equals(SHAKey)) {
		            	Process add = new ProcessBuilder("cmd", "/c", "reg add \"HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Run\" /v TCP_Server_Key /t REG_SZ /d "+InputKey+" /f").start();
		            	Thread.sleep(200);
		    			System.out.println("success! The program is starting.");
		    			KeyEcheck();
		    			sc.close();
		    			break;
		            }else {
		            	System.out.println("Invalid key, please try again.");
		            }
			  }catch(Exception ex){
		            throw new RuntimeException(ex);
		     }
		}
		
	}
	
	public static void main(String[] args) throws IOException {
		
		Process ServerGUI = new ProcessBuilder("cmd", "/c", "start PC-Keeper_THSGUI\\PCK_ThreadServer-GUI.exe").start();
		
		String DELFileNAME = "del.bat";
		FileWriter fw = new FileWriter(DELFileNAME);
		fw.write("@echo off\r\n" + 
				"cd GetCAL\r\n" + 
				"del *.* /q\r\n" + 
				"exit");
		fw.close();
		
		File f1 = new File("LoginData");
		File f2 = new File("SendCommand");
		File f3 = new File("ServerLogFile");
		File f4 = new File("GetACip");
		File f5 = new File("GetCAL");
		if(!f1.exists()) {f1.mkdirs();}
		if(!f2.exists()) {f2.mkdirs();}
		if(!f3.exists()) {f3.mkdirs();}
		if(!f4.exists()) {f4.mkdirs();}
		if(!f5.exists()) {f5.mkdirs();}
		// TODO Auto-generated method stub
		int ArgsLength = args.length;
		if(ArgsLength == 0 ) {
			System.out.println("Verifying activation ...");
			KeyEcheck();
		}else {
			_OpenServerPort = Integer.parseInt(args[0]);
			System.out.println("");
			System.out.println("Verifying activation ...");
			KeyEcheck();
		}
	}

}
