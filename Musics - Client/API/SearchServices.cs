﻿using System;
using Utility.Musics;
using Utility.Network.Dialog;
using ControlLibrary.Network;
using Musics___Client.API.Events;
using System.Collections.Generic;
using Utility.Network.Dialog.Requests;

namespace Musics___Client.API
{
    public class SearchServices
    {
        static private readonly Lazy<SearchServices> instance = new Lazy<SearchServices>(() => new SearchServices());
        static public SearchServices Instance { get => instance.Value; }

        private SearchServices()
        {
            NetworkClient.Packetreceived += NetworkClient_Packetreceived;
        }

        private void NetworkClient_Packetreceived(object sender, PacketEventArgs a)
        {
            if (a.Packet is RequestAnswer)
            {
                var requestAnswer = a.Packet as RequestAnswer;
                if (requestAnswer.RequestsTypes == RequestsTypes.Search)
                {
                    OnSearchResultEvent(new SearchResultEventArgs(requestAnswer.AnswerList));
                }
            }
        }

        public void SearchElement(string Search, ElementType elementType) 
            => NetworkClient.SendObject(new RequestSearch(Search, elementType));

        public event EventHandler<SearchResultEventArgs> SearchResultEvent;

        protected virtual void OnSearchResultEvent(SearchResultEventArgs e)
            => SearchResultEvent?.Invoke(this, e);


    }
}
