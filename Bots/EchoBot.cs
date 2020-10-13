// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace Microsoft.BotBuilderSamples.Bots
{
    public class EchoBot : ActivityHandler
    {
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            var contenido = turnContext.Activity.Text;
            var respuesta = "";
            switch (contenido)
            {
                case "hola":
                    respuesta = "Hola trabajador de ENAC, eres un privilegiado y yo un simple bot.";
                    break;
                case "adios":
                    respuesta = "Hasta luego, no me preguntes más, cansino.";
                    break;
                default:
                    respuesta = "No contemplo esa pregunta/frase. Mala suerte.";
                    break;
            }

            await turnContext.SendActivityAsync(MessageFactory.Text(respuesta, respuesta), cancellationToken);
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            var welcomeText = "Bienvenido al bot de ENAC, soy muy majo :)";
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
                }
            }
        }
    }
}
