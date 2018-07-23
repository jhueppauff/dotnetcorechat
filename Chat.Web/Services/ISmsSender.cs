/*
 * -----------------------------------------------------------------------
 *  <copyright file="ISmsSender.cs" company=""
 *  Copyright 2018 julian
 *  MIT Licence
 *  For licence details visit https://github.com/jhueppauff/dotnetcorechat/blob/master/LICENSE
 *  </copyright>
 * -----------------------------------------------------------------------
 */

using System.Threading.Tasks;

namespace dotnetcorechat.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}