//-----------------------------------------------------------------------
// <copyright file="Attachment.cs" company="Code Miners Limited">
//     Copyright (c) 2019
// </copyright>
//-----------------------------------------------------------------------

namespace Core.Modules.Communications.Sendgrid.Models
{
    using System;

    public sealed class Attachment : IEquatable<Attachment>
    {
        private readonly bool empty;

        /// <summary>
        /// Gets the filename of the attachment
        /// </summary>
        public string Filename { get; }

        /// <summary>
        /// Gest the file data for the attachment (base64 encoded)
        /// </summary>
        public string FileData { get; }

        /// <summary>
        /// An empty instance of an attachment
        /// </summary>
        public static Attachment Empty { get; } = new Attachment();

        /// <summary>
        /// Private initialiser to allow Attachment.Empty
        /// </summary>
        private Attachment()
        {
            empty = true;
            FileData = string.Empty;
            Filename = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="fileData"></param>
        public Attachment(string filename, string fileData)
        {
            empty = false;
            Filename = filename;
            FileData = fileData;
        }

        public static bool IsNullOrEmpty(Attachment attachment)
        {
            if (attachment == null)
            {
                return true;
            }

            return attachment.empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Attachment other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (empty.Equals(other.empty))
            {
                return true;
            }

            return Filename.Equals(other.Filename) && FileData.Equals(other.FileData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Attachment b = obj as Attachment;
            if (ReferenceEquals(b, null))
            {
                return false;
            }

            return Equals(b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Filename.GetHashCode() ^ FileData.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static bool operator ==(Attachment a, Attachment b)
        {
            if (ReferenceEquals(a, null))
            {
                return ReferenceEquals(b, null);
            }

            return a.Equals(b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Attachment a, Attachment b)
        {
            return !(a == b);
        }

        public static explicit operator byte[](Attachment data)
        {
            if (IsNullOrEmpty(data))
            {
                return new byte[0];
            }

            return Convert.FromBase64String(data.FileData);
        }
    }
}