using System;
using System.IO;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        Console.WriteLine("変換元のテキストファイルのパスを入力してください:");
        string inputFilePath = Console.ReadLine();   // 変換元のテキストファイルのパス

        try
        {
            ConvertTextToJson(inputFilePath);
            Console.WriteLine("変換が完了しました。");
        }
        catch (Exception ex)
        {
            Console.WriteLine("変換中にエラーが発生しました:");
            Console.WriteLine(ex.Message);
        }
    }

    static void ConvertTextToJson(string inputFilePath)
    {
        // テキストファイルを読み込む
        string text = File.ReadAllText(inputFilePath);

        // JSONオブジェクトに変換する
        var json = new { text = text };

        // 参考にしたテキストファイルと同じ場所にJSONファイルを作成する
        string outputFilePath = Path.ChangeExtension(inputFilePath, ".json");

        // JSONファイルに書き出す
        string jsonData = JsonConvert.SerializeObject(json);
        File.WriteAllText(outputFilePath, jsonData);
    }
}
