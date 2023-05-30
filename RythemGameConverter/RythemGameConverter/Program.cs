using System;
using System.IO;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        Console.WriteLine("変換元のテキストファイルのパスを入力してください:");
        string inputFilePath = Console.ReadLine();   // 変換元のテキストファイルのパス

        Console.WriteLine("変換後のJSONファイルのパスを入力してください:");
        string outputFilePath = Console.ReadLine();   // 変換後のJSONファイルのパス

        try
        {
            ConvertTextToJson(inputFilePath, outputFilePath);
            Console.WriteLine("変換が完了しました。");
        }
        catch (Exception ex)
        {
            Console.WriteLine("変換中にエラーが発生しました:");
            Console.WriteLine(ex.Message);
        }        
    }

    static void ConvertTextToJson(string inputFilePath, string outputFilePath)
    {
        // テキストファイルを読み込む
        string text = File.ReadAllText(inputFilePath);

        // JSONオブジェクトに変換する
        var json = new { text = text };

        // JSONファイルに書き出す
        string jsonData = JsonConvert.SerializeObject(json);
        File.WriteAllText(outputFilePath, jsonData);
    }
}
