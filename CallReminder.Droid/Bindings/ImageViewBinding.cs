using System;
using Android.Support.Annotation;
using Android.Widget;
using FlexiMvvm.Bindings;
using FlexiMvvm.Bindings.Custom;
using Uri = Android.Net.Uri;

namespace CallReminder.Droid.Bindings
{
    internal static class ImageViewBinding
    {
        [NonNull]
        public static TargetItemBinding<ImageView, Uri> SetImageUriBinding(
            [NonNull] this IItemReference<ImageView> imageViewReference)
        {
            if (imageViewReference == null)
            {
                throw new ArgumentNullException(nameof(imageViewReference));
            }

            return new TargetItemOneWayCustomBinding<ImageView, Uri>(
                imageViewReference,
                (imageView, uri) => imageView.SetImageURI(uri),
                () => "SetImageUri");
        }

        [NonNull]
        public static TargetItemBinding<ImageView, int> SetImageResourceBinding(
            [NonNull] this IItemReference<ImageView> imageViewReference)
        {
            if (imageViewReference == null)
            {
                throw new ArgumentNullException(nameof(imageViewReference));
            }

            return new TargetItemOneWayCustomBinding<ImageView, int>(
                imageViewReference,
                (imageView, resourse) => imageView.SetImageResource(resourse),
                () => "SetImageResource");
        }
    }
}