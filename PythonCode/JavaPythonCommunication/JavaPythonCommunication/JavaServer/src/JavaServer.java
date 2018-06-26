import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;

public class JavaServer 
{
	public static void main(String args[]) throws IOException
	{
		String fromClient;
        String toClient;

        ServerSocket server = new ServerSocket(8080);
        System.out.println("wait for connection on port 8080");

        boolean run = true;
        while(run) {
            Socket client = server.accept();
            System.out.println("got connection on port 8080");
            BufferedReader in = new BufferedReader(new InputStreamReader(client.getInputStream()));
            PrintWriter out = new PrintWriter(client.getOutputStream(),true);
            
          //  BufferedWriter sockOut = new BufferedWriter(new OutputStreamWriter(socket.getOutputStream()));
           // BufferedReader sockIn = new BufferedReader(new InputStreamReader(socket.getInputStream()));

            //fromClient = in.readLine();
            String methodName, fileNam, contents;
            methodName=in.readLine();
            fileNam=in.readLine();
            contents=in.readLine();
          //  System.out.println("typing: " + fromClient);
            //System.out.println("received: " + fromClient);
           // System.out.println("typing2: " + fromClient);
            ArrayList<String> methodNames=new ArrayList<String>();
            methodNames.add("writeFile");
            if(methodNames.contains(methodName))
            {
            	if(methodName.equals("writeFile"))
            	{
            		writeFile(fileNam, contents);
            	}
            }
            System.out.println("Done!");
            out.println("Done!!");
            client.close();
           // writeFile("Hello","hkjgbjhvgc");
        /*    if(fromClient.equals("Hello")) {
                toClient = "olleH";
                System.out.println("send olleH");
                out.println(toClient);
                fromClient = in.readLine();
                System.out.println("received: " + fromClient);}  */

/*            if(fromClient.equals("Hello")) {
                toClient = "olleH";
                System.out.println("send olleH");
                out.println(toClient);
                fromClient = in.readLine();
                System.out.println("received: " + fromClient);

                if(fromClient.equals("Bye")) {
                    toClient = "eyB";
                    System.out.println("send eyB");
                    out.println(toClient);
                    client.close();
                    run = false;
                    System.out.println("socket closed");
                }*/
            //}
            //HashMap 
        }
        System.exit(0);
    }
		
	
	public static String writeFile(String fileName, String contents)
	{
		try
		{
			 BufferedWriter output = null;
			File file = new File(fileName+".txt");
            output = new BufferedWriter(new FileWriter(file));
            output.write(contents);
			/*PrintWriter writer = new PrintWriter("fileName.txt", "UTF-8");
			writer.println(contents);
			//writer.println("The second line");
			writer.close();*/
            output.close();
			
		}
		catch(Exception e)
		{
			return "Sorry! Didn't work";
		}
		return "File created and wrote to!";
	}
	

}
