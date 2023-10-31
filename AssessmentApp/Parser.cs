﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    public class Parser
    {
        private Graphics graphics;
        /// <summary>
        ///     Parses a single line input into the textbox1 on the form
        /// </summary>
        /// <param name="input">The user input form the form</param>
        /// <returns>The command that has been build from the input that 
        /// will be used to do something on the form's picturebox</returns>
        internal Command ParseLine(string input, Graphics graphics)
        {
            this.graphics = graphics;
            return BuildCommand(input);
        }

        /// <summary>
        ///     Converts the  input into lower case and then the title case version 
        ///     of itself so that it can be checked agains the actions enum
        /// </summary>
        /// <param name="input">User input</param>
        /// <returns>User's input in title string</returns>
        internal String TitleCase(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        /// <summary>
        ///     Takes the user's input and uses ExtactAction to find out what the
        ///     type of command it is.
        ///     Then uses ExtractNumbers to find out what will be used for the size
        ///     peramiters
        /// </summary>
        /// <param name="input">The user's input</param>
        /// <returns>The build command wiht the action and the peramiters split up</returns>
        internal Command BuildCommand(string input)
        {
            IEnumerable<string> token = input.Trim().ToLower().Split(' ').ToList();
            var action = ExtractAction(token);
            var color = ExtractColor(token);
            var onoff = ExtractOnOff(token);
            var numbers = ExtractNumbers(token);
            return new Command(action, numbers, graphics);
        }

        /// <summary>
        ///     Gets the list of Actions, proccesses the input and then checks to see if the
        ///     inut is in the Actions enum. If the input evalutes to be null or empty then
        ///     the action "None" is passed and nothing happens.
        ///     If not it tries to pass the token as a Action form the enum.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public  Action ExtractAction(IEnumerable<string> tokens) 
        {
            var actions = Enum.GetNames(typeof(Action));
            var firstAction = tokens.Select(TitleCase).FirstOrDefault(token => actions.Contains(token));
            return string.IsNullOrEmpty(firstAction) ? Action.None : (Action)Enum.Parse(typeof(Action), firstAction);
        }

        /// <summary>
        ///     Gets the numbers from the input passed but tests to see if they can be parsed
        ///     as ints before actually doing so. and then returns the number token once it
        ///     is able to parse the token as an int
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public int[] ExtractNumbers(IEnumerable<string> token)
        {
            var numberToken = token.Select(token => token.Trim())
                .Where(token => int.TryParse(token, out _))
                .Select(token => int.Parse(token));
            return numberToken.ToArray();
        }

        public bool IsVariableDeclaration(string line)
        {
          throw new NotImplementedException();
        }
        public IEnumerable<int> ExtractVariables(IEnumerable<string> tokens)
        {
            throw new NotImplementedException();
        }
        public bool ExtractVariableAssignment(string line)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the enum of colours, and checks to see if this colour given is in that 
        ///     list by trying to parse it as one of the values in the enum, it returns the 
        ///     given colour if it is in the enum, otherwise it deafults to black
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Color ExtractColor(IEnumerable<string> token)
        {
            var color = Enum.GetNames(typeof(Colors));
            var firstColor = token.Select(TitleCase)
                .FirstOrDefault(token => color.Contains(token));
            return string.IsNullOrEmpty(firstColor) ? Color.Black : (Color)Enum.Parse(typeof(Color), firstColor);
        }

        public bool? ExtractOnOff(IEnumerable<string> tokens)
        {
            bool? result = null;
            if (tokens.Equals("On"))
            {
                result = true;
                return result;
            }
            else if (tokens.Equals("Off"))
            {
                result = false;
                return result;
            }
            else { return null; }
        }
        /*
        public IEnumerable<Command> ParseProgram(string input)
        {
            string[] lines = input.Split('\n');
            foreach (var line in lines)
            {
                Command command = ParseLine(line);
                return command;
            }
        }
        */
    }
}
