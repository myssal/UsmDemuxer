using System;
using System.CommandLine;
using System.CommandLine.NamingConventionBinder;
using System.Threading.Tasks;
using VGMToolbox.format;

namespace UsmDemuxer
{
	class Program
	{
		static async Task<int> Main(string[] args)
		{
			// Required input file argument
			var inputArg = new Argument<string>(
				name: "input",
				description: "Path to the .usm file"
			);

			// Optional flags
			var extractAudioOption = new Option<bool>(
				name: "--extract_audio",
				description: "Extract audio stream."
			);

			var extractVideoOption = new Option<bool>(
				name: "--extract_video",
				description: "Extract video stream."
			);

			var addHeaderOption = new Option<bool>(
				name: "--add_header",
				description: "Add ADX/AAC header to audio stream."
			);

			var splitAudioStreamsOption = new Option<bool>(
				name: "--split_audio_streams",
				description: "Split audio into multiple streams if present."
			);

			// Combine into root command
			var rootCommand = new RootCommand("CRI USM Demuxer")
			{
				inputArg,
				extractAudioOption,
				extractVideoOption,
				addHeaderOption,
				splitAudioStreamsOption
			};

			rootCommand.Handler = CommandHandler.Create<string, bool, bool, bool, bool>(
				(input, extract_audio, extract_video, add_header, split_audio_streams) =>
				{
					var options = new MpegStream.DemuxOptionsStruct
					{
						ExtractAudio = extract_audio,
						ExtractVideo = extract_video,
						AddHeader = add_header,
						SplitAudioStreams = split_audio_streams
					};

					try
					{
						new CriUsmStream(input).DemultiplexStreams(options);
					}
					catch (Exception ex)
					{
						Console.Error.WriteLine($"Error: {ex.Message}");
						return 1;
					}

					return 0;
				});

			return await rootCommand.InvokeAsync(args);
		}
	}
}