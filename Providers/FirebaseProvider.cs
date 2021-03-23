using System;
using System.Threading.Tasks;
using AURoomAPI.Interfaces;
using Firebase.Database;
using AURoomAPI.Models;
using Firebase.Database.Query;

namespace AURoomAPI.Providers
{
    public class FirebaseProvider : IFirebaseProvider
    {
        protected readonly FirebaseClient _firebase;

        public FirebaseProvider()
        {
            _firebase = new FirebaseClient(Path.BaseUrl);
        }

        public void IsComputing()
        {
            _firebase.Child(Path.IsComputing)
                     .PutAsync(true);
        }

        public void IsError(string message)
        {
            _firebase.Child(Path.IsError)
                     .PutAsync(true);

            _firebase.Child(Path.ErrorMessage)
                     .PutAsync(message);

            Finish();
        }

        public void IsProcessing()
        {
            _firebase.Child(Path.IsProcessing)
                     .PutAsync(true);
        }

        public void IsRetrieving()
        {
            _firebase.Child(Path.IsRetrieving)
                     .PutAsync(true);
        }

        public void IsUpdating()
        {
            _firebase.Child(Path.IsUpdating)
                     .PutAsync(true);
        }

        public void Finish()
        {
            _firebase.Child(Path.IsAutomate)
                     .PutAsync(false);
            _firebase.Child(Path.IsComputing)
                     .PutAsync(false);

            _firebase.Child(Path.IsError)
                     .PutAsync(false);

            _firebase.Child(Path.IsProcessing)
                     .PutAsync(false);

            _firebase.Child(Path.IsRetrieving)
                     .PutAsync(false);

            _firebase.Child(Path.IsUpdating)
                     .PutAsync(false);

            _firebase.Child(Path.ErrorMessage)
                     .PutAsync("");
        }
        
        public async Task<Boolean> IsDissolving()
        {
            await _firebase.Child(Path.IsDissolving)
                           .PutAsync(true);

            return true;
        }

        public async Task<Boolean> FinishDissolving()
        {
            await _firebase.Child(Path.IsDissolving)
                           .PutAsync(false);

            return true;
        }

        public void IsAutomate()
        {
            _firebase.Child(Path.IsAutomate)
                     .PutAsync(true);
        }
    }
}