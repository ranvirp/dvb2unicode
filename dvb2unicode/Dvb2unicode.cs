//------------------------------------------------------------------------------
// <copyright file="CSSqlFunction.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{

    static readonly string[] array_one ={"‚","ƒ","„","…","±ÎÌ","±ÏÌ","†Öò","Öò","†Öê","†Öî","†Ö","†","‡Ô","‡","‰","ˆ","Š","‹ê","‹","†ÖêÓ","†ÖîÓ",
              
              "ŒÌ","Œ","Ì","","Î", "","Ì","","Ì","","Î","‘","’",
              
              "“","”","•Ì","•","–","—","˜",
              
              "™","š","›","œ","",
              
              "Ÿ","¡","¢","£","¤","¥","¦","§","¨","©","ª","«","­","®",
              "¬",
              
              "¯","°Ì","±Ì","°","±","²","³","´",
              
              "µ","•","¸","¹","º","»","ó","ô","¾",
              
              "¿","À","Á","Â","Ã",
              
              "¼","½",
              
              "Ä","Å","Æ","Ç","È","É","Ê",
              
              "Ë","Ì","Í","Î","Ï",
              
              "Ð","Ñ","Ò","Ó",
              
              "÷","ø","ù","ú","û","ü","ý","þ",
              "Öê","Öî","ê","î","Ö","्ा","ß","ã","å","æ","è","é","ë","ï","ò",
              "ú","û","ü","ý","þ",
              "आे","¬","्ो","्ौ"};

static readonly string[] array_two = {
                                 
                                 "ॐ","ऽ","ः","।","फ़्र","फ़्र",
                                 "ऑ","ॉ",
                                 "ओ","औ","आ","अ","ई","इ","ऊ","उ","ऋ","ऐ","ए","ओं","औं",
                                 
                                 "क़्","क्","क़","क","क्र","क्ष्","ख़्","ख्","ग़्","ग्","ग्र्","घ्","ङ",
                                 
                                 "च्","छ","ज़्","ज्","ज्ञ्","झ्","ञ्",
                                 
                                 "ट","ठ","ड","ढ","ण्",
                                 
                                 "त्","त्र्","त्त्","थ्","द","दृ","द्र","द्द","द्ध","द्म","द्य","द्व","न्","न्न्",
                                 "ध्",
                                 
                                 "प्","फ़्","फ़","फ्","फ","ब्","भ्","म्",
                                 
                                 "य्","्य","र","रु","रू","ल्","ळ्","ळ","व्",
                                 
                                 "श्","श्","श्र्","ष्","स्",
                                 
                                 "ट्ट","ट्ठ",
                                 
                                 "रु","ह्","ह","हृ","ह्र","ह्म","ह्य",
                                 
                                 "्","़","़","्र","्र",
                                 
                                 "्र","ँ","्र","ं",
                                 
                                 // "Ô","Õ","×","Ø","Ù","Ú","Û","Ü","Ý","Þ",
                                 
                                 // "र्","र्ं","ि","िं","र्ि","र्िं","ि","िं","र्ि","र्िं",
                                 //
                                 //"à","á","â","ä","ç","ì","í","ð","ñ",
                                 //"ीं","र्ी","र्ीं","्रु","्रू","र्े","र्ें","र्ै","र्ैं",
                                 
                                 "ट्ठ","ड्ड","ड्ढ","","","","","",
                                 
                                 "ो","ौ","े","ै","ा","","ी","ु","ु","ू","ू","ृ","ें","ैं","ॅ",
                                 "","","","","",
                                 //"ओ","ध्","े","ौ"};
                                 "ओ","ध्","े","ै"};
           static readonly int array_one_length = 133;    
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlString Dvb2unicode(SqlString x)
    {
        // Put your code here
        //return new SqlString (string.Empty);
      //  return (SqlString) "खोज के शब्द यहाँ";
        return (SqlString) UserDefinedFunctions.converter((string) x);
        
    }
 static   string Replace_Symbols(string  modified_substring)
    {
        //substitute array_two elements in place of corresponding array_one elements
        
        if (modified_substring != "")  // if stringto be converted is non-blank then no need of any processing.
        {
            for (int input_symbol_idx = 0; input_symbol_idx < UserDefinedFunctions.array_one_length; input_symbol_idx++)
            {
                
                //  alert(" modified substring = "+modified_substring)
                
                //***********************************************************
                // if (input_symbol_idx==106) 
                //  { alert(" input_symbol_idx = "+input_symbol_idx);
                //    alert(" input_symbol_idx = "+input_symbol_idx)
                //; alert(" character =" + modified_substring.CharCodeAt(input_symbol_idx))
                //     alert(" character = "+modified_string.fromCharCode(input_symbol_idx)) 
                //   }
                // if (input_symbol_idx == 107) 
                //   { alert(" input_symbol_idx = "+input_symbol_idx);
                //    alert(" character = ",+string.fromCharCode(input_symbol_idx)) 
                //   }
                //***********************************************************
                int idx = 0;
   while (idx != -1) //while-00
                {
                   string x = array_one[input_symbol_idx];
                    string y = array_two[input_symbol_idx];
                    
                     modified_substring=modified_substring.Replace(x,y);
                    idx = -1;
                    // MessageBox.Show(modified_substring[0]);
                    //modified_substring.i
                    //modified_substring.
                    //idx = modified_substring.IndexOf(array_one[input_symbol_idx]);
                    
                } // end of while-00 loop
                // alert(" end of while loop")
            } // end of for loop
            // alert(" end of for loop")
            
            // alert(" modified substring2 = "+modified_substring)
            
            //**********************************************************************************
            // Code for Replacing twelve Special glyphs
            //**********************************************************************************
            // Glyph00 : ¬ (dh)
            //**********************************************************************************
            // modified_substring = modified_substring.replace( /¬/g , "ध्" ) ;
            //**********************************************************************************
            // Glyph01 : Õ (reph+anusvAr)
            // Glyph   : Öí (okAr+reph+anusvAr)
            // Glyph02 : í (ekAr+reph+anusvAr)
            // Glyph03 : ì (ekAr+reph)
            // Glyph04 : ñ (aikAr+reph+anusvAr)
            // Glyph05 : ð (aikAr+reph)
            // Glyph06 : á ( reph + ी )
            // Glyph07 : à ( ी + anusvAr )
            // Glyph08 : â ( reph + ी + anusvAr )
            // Glyph09 : Ù  ( reph + ि )
            // Glyph10 : Û  (ि) [ikAr mAtrA before a संयुक्ताक्षर as in क्लिष्ट, स्थित etc)
            // Glyph11 : Ø ("िं") 
            // Glyph12 : Ú ("र्िं")
            //**********************************************************************************
            // Code for Glyph1 : Õ (reph+anusvAr)
            //**********************************************************************************
             modified_substring=modified_substring=modified_substring.Replace("Õ","Ôं"); // at some places  ì  is  used eg  in "कर्कंधु,पूर्णांक".
            
            //**********************************************************************************
            // Code for Glyph2 : í (ekAr+reph+anusvAr)
            //**********************************************************************************
             modified_substring=modified_substring.Replace("Öí","ोंÔ");
            modified_substring=modified_substring.Replace("í","Ôें");
            
            //**********************************************************************************
            // Code for Glyph3 : ì (ekAr+reph)
            //**********************************************************************************
            modified_substring=modified_substring.Replace("ì","Ôे");
            
            //**********************************************************************************
            // Code for Glyph4 : ñ (aikAr+reph+anusvAr)
            //**********************************************************************************
            modified_substring=modified_substring.Replace("ñ","Ôैं");
            
            //**********************************************************************************
            // Code for Glyph5 : ð (aikAr+reph)
            //**********************************************************************************
            modified_substring=modified_substring.Replace("ð","Ôै");
            
            //**********************************************************************************
            // Code for Glyph6 : á ( reph + ी )
            //**********************************************************************************
            modified_substring=modified_substring.Replace("á","Ôी");
            
            //**********************************************************************************
            // Code for Glyph7 : à ( ी + anusvAr )
            //**********************************************************************************
              modified_substring=modified_substring.Replace("à","ीं");
            
            //**********************************************************************************
            // Code for Glyph8 : â ( reph + ी + anusvAr )
            //**********************************************************************************
             modified_substring=modified_substring.Replace("â","Ôीं");
            
            //**********************************************************************************
            // Code for Glyph09 : Ù  ( reph + ि )
            // Code for Glyph10 : Û  (ि) [ikAr mAtrA before a संयुक्ताक्षर as in क्लिष्ट, स्थित etc)
            //   replace "×" and "Û" with "ि" and correcting its position too(moving it one position forward)
            //**********************************************************************************
             modified_substring=modified_substring.Replace("Ù","र्×");  // at some places  Ì  is  used eg  in "धार्मिक".
              modified_substring=modified_substring.Replace("Û","×");
            
            int position_of_i =modified_substring.IndexOf("×");
            int sublength = 0;
           // stringstream ss;
            //http://stackoverflow.com/questions/137487/null-vs-false-vs-0
            while (position_of_i!=-1)  //while-02
            {
				//print position_of_i.":".modified_substring ."<br>";
                
                //print position_of_i."<br>";
                position_of_i += sublength;
                //print "modified_substring <br>";
                //string charecter_next_to_i;
                //="ल";
                //cout <<position_of_i;
               // string::iterator   w = modified_substring.begin() +position_of_i;
                //uint32_t nextc = utf8::next(w,modified_substring.end());
                //string charecter_next_to_i ;
                //ss<<*w;
                //ss>>charecter_next_to_i;
                
              //  string charecter_next_to_i = modified_substring.Substring(position_of_i+2 ,3);
                try
                {
                    char charecter_next_to_i = modified_substring[position_of_i + 1];

                    //string::iterator i;

                    //string charecter_next_to_i = utf8::next(&modified_substring+position_of_i+1,&modified_substring+position_of_i+2);

                    //cout<< charecter_next_to_i + "ि"+ " is character next to i \n ";
                    string charecter_to_be_replaced = "×" + charecter_next_to_i;
                    //cout<< charecter_to_be_replaced+"\n";
                    modified_substring = modified_substring.Replace(charecter_to_be_replaced, charecter_next_to_i + "ि");
                    //print "modified_substring <br>";

                    string x = modified_substring.Substring(position_of_i + 1);
                    sublength = modified_substring.Length - x.Length;
                    position_of_i = x.IndexOf("×"); // search for i ahead of the current position.
                    //print "modified_substring <br>";
                } catch(Exception e)
                {
                    break;
                }
                
            } // end of while-02 loop
            
            //**********************************************************************************
            // Code for Glyph11 : Ø ("िं") 
            // Code for Glyph12 : Ú ("र्िं")
            //   replace Ú with "िं"  and correcting its position too(moving it two positions forward)
            //**********************************************************************************
              modified_substring=modified_substring.Replace("Ú","र्Ø"); // at some places  Í  is  used eg  in "शर्मिंदा"
             modified_substring=modified_substring.Replace("Ø","×Ó"); // at some places  Ë  is  used eg  in "किंकर".
            
            position_of_i =modified_substring.IndexOf("×Ó");
            sublength = 0;
            while (position_of_i!=-1)  //while-02
            {
                try
                {
                    position_of_i += sublength;
                    char charecter_next_to_ip2 = modified_substring[position_of_i + 2];
                    string charecter_to_be_replaced = "×Ó" + charecter_next_to_ip2;
                    modified_substring = modified_substring.Replace(charecter_to_be_replaced, charecter_next_to_ip2 + "िं");
                    string x = modified_substring.Substring(position_of_i + 4);
                    sublength = modified_substring.Length - x.Length;
                    position_of_i = x.IndexOf("×Ó");   // search for i ahead of the current position.
                }catch (Exception e)
                {
                    break;
                }
                
            } // end of while-02 loop
            
            
            //**********************************************************************************
            // End of Code for Replacing four Special glyphs
            //**********************************************************************************
            
            // following loop to eliminate 'chhotee ee kee maatraa' on half-letters as a result of above transformation.
            
            int position_of_wrong_ee =modified_substring.IndexOf("ि्");
            sublength = 0;
            position_of_i = 0;
            while (position_of_wrong_ee!=-1)  //while-03
            {
                try
                {
                    position_of_i += sublength;
                    char consonent_next_to_wrong_ee = modified_substring[position_of_wrong_ee + 2];
                    string charecter_to_be_replaced = "ि्" + consonent_next_to_wrong_ee;
                    modified_substring = modified_substring.Replace(charecter_to_be_replaced, "्" + consonent_next_to_wrong_ee + "ि");
                    string x = modified_substring.Substring(position_of_i + 3);
                    sublength = modified_substring.Length - x.Length;

                    position_of_wrong_ee = x.IndexOf("ि्"); // search for 'wrong ee' ahead of the current position. 
                }catch (Exception e)
                {
                    break;
                }
                
            } // end of while-03 loop
            
            
            // Eliminating reph "Ô" and putting 'half - r' at proper position for this.
            string set_of_matras = "ा ि ी ु ू ृ े ै ो ौ ं : ँ ॅ";
            int position_of_R =modified_substring.IndexOf("Ô");
            
            while (position_of_R !=-1)  // while-04
            {
                try
                {
                    int probable_position_of_half_r = position_of_R - 1;
                    string charecter_at_probable_position_of_half_r = modified_substring.Substring(probable_position_of_half_r, 1);


                    // trying to find non-maatra position left to current O (ie, half -r).

                    while (set_of_matras.IndexOf(charecter_at_probable_position_of_half_r) > 0)  // while-05
                    {
                        probable_position_of_half_r = probable_position_of_half_r - 1;
                        charecter_at_probable_position_of_half_r = modified_substring.Substring(probable_position_of_half_r, 1);

                    } // end of while-05


                    string charecter_to_be_replaced = modified_substring.Substring(probable_position_of_half_r, (position_of_R - probable_position_of_half_r));
                    string new_replacement_string = "र्" + charecter_to_be_replaced;
                    charecter_to_be_replaced = charecter_to_be_replaced + "Ô";
                    modified_substring = modified_substring.Replace(charecter_to_be_replaced, new_replacement_string);
                    position_of_R = modified_substring.IndexOf("Ô");
                } catch (Exception e)
                {
                    break;
                }
                
            } // end of while-04
            
        } // end of IF  statement  meant to  supress processing of  blank  string.
        
         modified_substring=modified_substring.Replace("ाे","ो");
          modified_substring=modified_substring.Replace("ाै","ौ");
        
        
        return modified_substring;
    } // end of the function  Replace_Symbols
   
static string converter(string input)
    {
        //input=utf8_encode(input);
        //print "input <br>";
        string modified_substring="";
       // cout<<input;
        //****************************************************************************************
        //  Break the long text into small bunches of max. max_text_size  characters each.
        //****************************************************************************************
        int text_size = input.Length;
        string processed_text = "";  //blank
        //processed_text=utf8_encode(processed_text);
        //**********************************************
        //    alert("text size = "+text_size);
        //**********************************************
        
        int sthiti1 = 0; int sthiti2 = 0; int chale_chalo = 1;
        
        int max_text_size = 60000;
        
        while (chale_chalo == 1)
        {
            sthiti1 = sthiti2;
            
            if (sthiti2 < (text_size - max_text_size))
            {
                sthiti2 += max_text_size;
                while (input.Substring(sthiti2,1) != " ") { sthiti2--; }
            }
            else { sthiti2 = text_size; chale_chalo = 0; }
            
            //   alert(" sthiti 1 = "+sthiti1); alert(" sthit 2 = "+sthiti2) 
            
            modified_substring = input.Substring(sthiti1, sthiti2);

       //    modified_substring= UserDefinedFunctions.Replace_Symbols(modified_substring);
            
            processed_text += modified_substring;
            
            
            //****************************************************************************************
            //  Breaking part code over
            //****************************************************************************************
            //  processed_text = processed_text.replace( /mangal/g , "DVB-TTYogeshEN " ) ;   
            
        }
        //print "Final is processed_text<br>";
        return UserDefinedFunctions.Replace_Symbols(input); ;
        
    }
}
