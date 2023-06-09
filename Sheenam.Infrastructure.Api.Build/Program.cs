﻿
var aDotNetClient = new ADotNetClient();

var githubPipeline = new GithubPipeline
{
    Name = "Github",

    OnEvents = new Events
    {
        Push = new PushEvent
        {
            Branches = new string[] { "master" }
        },

        PullRequest = new PullRequestEvent
        {
            Branches = new string[] { "master" }
        }
    },

    Jobs = new Jobs
    {
        Build = new BuildJob
        {
            RunsOn = BuildMachines.Windows2019,

            Steps = new List<GithubTask>
              {
                  new CheckoutTaskV2
                  {
                      Name = "Check out"
                  },

                  new SetupDotNetTaskV1
                  {
                      Name = "Setup .Net",

                      TargetDotNetVersion = new TargetDotNetVersion
                      {
                          DotNetVersion = "6.0.100-rc.1.21463.6",
                          IncludePrerelease = true
                      }
                  },

                  new RestoreTask
                  {
                      Name = "Restore"
                  },

                  new DotNetBuildTask
                  {
                      Name = "Build"
                  },

                  new TestTask
                  {
                      Name = "Test"
                  }
              }
        }
    }
};

aDotNetClient.SerializeAndWriteToFile(githubPipeline, "../../../../.github/workflows/dotnet.yml");