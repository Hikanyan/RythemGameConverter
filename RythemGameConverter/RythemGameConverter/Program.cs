using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("変換元のテキストファイルのパスを入力してください:");
        string inputFilePath = Console.ReadLine();   // 変換元のテキストファイルのパス

        try
        {
            CreateJson(inputFilePath);
            Console.WriteLine("変換が完了しました。");
        }
        catch (Exception ex)
        {
            Console.WriteLine("変換中にエラーが発生しました:");
            Console.WriteLine(ex.Message);
        }
    }

    static void CreateJson(string inputFilePath)
    {
        // テキストファイルを読み込んでJSONオブジェクトに変換する
        var json = ConvertTextToJson(inputFilePath);
        // 参考にしたテキストファイルと同じ場所にJSONファイルを作成する
        string outputFilePath = Path.ChangeExtension(inputFilePath, ".json");

        // JSONファイルに書き出す
        string jsonData = JsonConvert.SerializeObject(json, Formatting.Indented);
        File.WriteAllText(outputFilePath, jsonData);
    }

    static JObject ConvertTextToJson(string inputFilePath)
    {
        var json = new JObject();

        foreach (var line in File.ReadLines(inputFilePath))
        {
            if (line.StartsWith("#"))
            {
                var parts = line.Split(new[] { ' ' }, 2);
                var key = parts[0].TrimStart('#');
                var value = parts.Length > 1 ? parts[1].Trim() : "";

                switch (key)
                {
                    case "TITLE":
                        json["title"] = value;
                        break;
                    case "ARTIST":
                        json["artist"] = value;
                        break;
                    case "DESIGNER":
                        json["designer"] = value;
                        break;
                    case "DIFFICULTY":
                        json["difficulty"] = Convert.ToInt32(value);
                        break;
                    case "PLAYLEVEL":
                        json["playLevel"] = Convert.ToInt32(value);
                        break;
                    case "SONGID":
                        json["songId"] = value;
                        break;
                    case "WAVE":
                        json["wave"] = value;
                        break;
                    case "WAVEOFFSET":
                        json["waveOffset"] = Convert.ToInt32(value);
                        break;
                    case "JACKET":
                        json["jacket"] = value;
                        break;
                    default:
                        break;
                }
            }
        }
        return json;
    }
}
