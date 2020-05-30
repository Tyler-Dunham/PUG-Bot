﻿using Discord_Bot_Tutorial.Context;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.EventHandling;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Discord_Bot_Tutorial.Models;
using System.Threading.Channels;
using System.Threading;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq.Expressions;

namespace Discord_Bot_Tutorial.Commands
{
    class PUGCommands : BaseCommandModule
    {
        [Command("q")]
        [Aliases("queue")]
        public async Task Q(CommandContext ctx, string role="view")
        {
            using (SqliteContext lite = new SqliteContext())
            {
                string[] responses = { "dps", "tank", "support" };

                var author = ctx.Message.Author.Id;
                var queue = lite.playerQueue;
                var allProfiles = lite.Profiles;

                if (role == "view")
                {
                    if (queue.Count() == 0)
                    {
                        await ctx.Channel.SendMessageAsync("There is no one in the queue.");
                        return;
                    }

                    string message = "List of players queued" + "```";
                    foreach (var player in queue)
                    {
                        message = message + "\n" + $"{player.userName,-10} : {player.role,10}";
                    }

                    await ctx.Channel.SendMessageAsync(message + "```");
                    return;

                }

                else if (responses.Contains(role.ToLower()))
                {
                    foreach (var profile in allProfiles)
                    {
                        if (profile.userID == author)
                        {
                            if (profile.queue == true)
                            {
                                foreach (var player in queue)
                                {
                                    if (player.userID == author)
                                    {
                                        queue.Remove(player);
                                        queue.Add(player);

                                        await lite.SaveChangesAsync();

                                        await ctx.Channel.SendMessageAsync($"{ctx.User.Mention} Added to queue. Role: {role}.");
                                    }
                                }
                            }

                            profile.queue = true;
                            profile.role = role;

                            var newPlayer = new Queue();
                            newPlayer.role = role;
                            newPlayer.userID = author;
                            newPlayer.userName = ctx.User.Username;

                            queue.Add(newPlayer);
                            await lite.SaveChangesAsync();

                            await ctx.Channel.SendMessageAsync($"{ctx.User.Mention} Added to queue. Role: {role}.");
                        }
                    }
                }

                else
                {
                    await ctx.Channel.SendMessageAsync("Not a valid role.");
                }
            }
        }

        [Command("leave")]
        [Aliases("l")]
        public async Task Leave(CommandContext ctx)
        {
            using (SqliteContext lite = new SqliteContext())
            {
                var author = ctx.Message.Author.Id;
                var allProfiles = lite.Profiles;
                var queue = lite.playerQueue;

                foreach (var player in queue)
                {
                    if (player.userID == author)
                    {
                        foreach (var profile in allProfiles)
                        {
                            if (profile.userID == author)
                            {
                                profile.role = null;
                                profile.queue = false;
                                queue.Remove(player);

                                await lite.SaveChangesAsync();

                                await ctx.Channel.SendMessageAsync("You have left the queue");
                                return;
                            }
                        }
                    }
                }

                await ctx.Channel.SendMessageAsync($"{ ctx.User.Mention} you are not in queue");
            }
        }
    }
}
