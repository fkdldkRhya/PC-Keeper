package org.TCP_Server.Main;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Scanner;

public class INPUT_Thread extends Thread{
	public void run() {
		for(int A = 0 ; A < 90 ; A++) {
			Scanner sc = new Scanner(System.in);
			System.out.print("Server >>");
			String Line = sc.nextLine();
			
			if(Line.equalsIgnoreCase("stop")) {
				System.out.println("[WARNING] The server automatically shuts down after 5 seconds.");
				try {
					Thread.sleep(5000);
				} catch (InterruptedException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				System.out.println("[WARNING] Server Stop!");
				System.exit(0);
				sc.close();
				break;
			}else {
				//ARG 
				if(Line.equalsIgnoreCase("ar -g")) {
					System.out.print("Server@Administrator rights@Give@ID >>");
					Line = sc.nextLine();
					System.out.print("Server@Administrator rights@Give@Password >>");
					String Lines = sc.nextLine();
					
					File f = new File("LoginData\\"+Line+"#"+Lines+".db");
					if(f.exists()) {
						try {
						Scanner AR = new Scanner(f);
						String ARr = AR.nextLine();
						ARr = ARr.replace("0", "1");
						FileWriter ARw = new FileWriter(f);
						ARw.write(ARr);
						ARw.close();
						System.out.println("success! "+ARr);
						}catch(IOException e){}
					}else {
						System.out.println("Error! Can not add it because the information file of this IP is not existed.");
					}
				}else {
					if(Line.equalsIgnoreCase("ar -r")) {
						System.out.print("Server@Administrator rights@REMOVE@ID >>");
						Line = sc.nextLine();
						System.out.print("Server@Administrator rights@REMOVE@Password >>");
						String Lines = sc.nextLine();
						File f = new File("LoginData\\"+Line+"#"+Lines+".db");
						if(f.exists()) {
							try {
							Scanner AR = new Scanner(f);
							String ARr = AR.nextLine();
							ARr = ARr.replace("1", "0");
							FileWriter ARw = new FileWriter(f);
							ARw.write(ARr);
							ARw.close();
							System.out.println("success! "+ARr);
							}catch(IOException e){}
						}else {
							System.out.println("Error! Can not add it because the information file of this IP is not existed.");
						}
				}else {
					if(Line.equalsIgnoreCase("show -l -s")) {
						int FileL = 0;
						String path = TCP_Server._SaveIPListPath;
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
					}else {
						if(Line.equalsIgnoreCase("show -d")) {
							System.out.print("Server@Show@Data@IP >>");
							Line = sc.nextLine();
							File f = new File(TCP_Server._SaveIPListPath+"\\"+Line+".db");
							if(f.exists()) {
								try {
								Scanner AR = new Scanner(f);
								String ARr = AR.nextLine();
								String[] sD = ARr.split("#");
 								System.out.println("Host Name: "+sD[0]);
								}catch(IOException e){}
							}else {
								System.out.println("Error! Can not add it because the information file of this IP is not existed.");
							}
						}else {
							if(Line.equalsIgnoreCase("send -c")) {
								String IP = "";
								String Data = "";
								
								System.out.print("Server@Send@Command@ID >>");
								IP = sc.nextLine();
								System.out.print("Server@Send@Command@Command >>");
								Data = sc.nextLine();
								
								try {
									FileWriter fw = new FileWriter("SendCommand\\"+IP+".c");
									fw.write(Data);
									fw.close();
								} catch (IOException e) {
									// TODO Auto-generated catch block
									e.printStackTrace();
								}
							}else {
								if(Line.equalsIgnoreCase("add -u")) {
									String ID = "";
									String PASS = "";
									String Email = "";
									
									System.out.print("Server@ADD@USER@ID >>");
									ID = sc.nextLine();
									System.out.print("Server@ADD@USER@Password >>");
									PASS = sc.nextLine();
									System.out.print("Server@ADD@USER@Email >>");
									Email = sc.nextLine();
									try {
										FileWriter fw = new FileWriter("LoginData\\"+ID+"#"+PASS+".db");
										fw.write(Email+"#0");
										fw.close();
										System.out.println("success!");
									}catch(IOException e){}
								}else {
									if(Line.equalsIgnoreCase("remove -u")) {
										String ID = "";
										String PASS = "";
										System.out.print("Server@REMOVE@USER@ID >>");
										ID = sc.nextLine();
										System.out.print("Server@REMOVE@USER@Password >>");
										PASS = sc.nextLine();
											File f = new File("LoginData\\"+ID+"#"+PASS+".db");
											f.delete();
											f.delete();
											System.out.println("Removed.");
									}else {
										if(Line.equalsIgnoreCase("show -l -u")) {
											int FileL = 0;
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
													System.out.println("[DATA] ID:"+split[0]+" PASSWORD:"+split[1]+" Authority:"+ooo[1]);
													FileL = FileL + 1;
												}
											}
											System.out.println("[INFO] Number of IP's: " + FileL);
										}else {
											if(Line.equalsIgnoreCase("show -gui")) {
												try {
													Process ServerGUI = new ProcessBuilder("cmd", "/c", "start PC-Keeper_THSGUI\\PCK_ThreadServer-GUI.exe").start();
												} catch (IOException e) {
													// TODO Auto-generated catch block
													e.printStackTrace();
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
			A = 0;
		}
	}
}
}
