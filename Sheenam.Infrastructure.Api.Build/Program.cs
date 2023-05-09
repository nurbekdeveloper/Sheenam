//=======================
//Coperight(c)  Coalition  of Good  -  Hearted  Enginners 
// Free To Use Comfort and Peace 
//======================


using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV1s;

var githubPipline = new GithubPipeline
{
    Name = "Sheenam Build Pipepiline  ",
    OnEvents = new Events
    {
        PullRequest = new PullRequestEvent
        {
            Branches = new string[] { "master" }
        },
        Push = new PushEvent {
            Branches = new string[] { "master" }
        }
    },
    Jobs = new Jobs
    {
        Build = new BuildJob
        {
            RunsOn = BuildMachines.Windows2022,
            Steps = new List<GithubTask> {
                new CheckoutTaskV2
                {
                    Name = "Cheking Out Code "
                },
                new SetupDotNetTaskV1
                {
                    Name = "Setting Up Dotnet ",
                    TargetDotNetVersion = new TargetDotNetVersion
                    {
                        DotNetVersion = "7.0.203"
                    }
                },
                new RestoreTask {
                    Name = "Restoring Nuget Packages "

                },
                new RestoreTask
                {
                    Name = "Runing Tests "
                }
            }
        }
        }
    };
var client = new  ADotNetClient();
client.SerializeAndWriteToFile(adoPipeline: githubPipline, path: "../../../../.github/workflows/dotnet.yml");
