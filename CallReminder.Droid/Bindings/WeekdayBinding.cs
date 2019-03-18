using System;
using Android.Widget;
using CallReminder.Core.Presentation.ValueConverters;
using CallReminder.Droid.Views;
using FlexiMvvm.Bindings;
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;

namespace CallReminder.Droid.Bindings
{
    internal static class WeekdayBinding
    {
        public static TargetItemBinding<WeekDayFragmentViewHolder, DayOfWeeksFlags> WeekdayCheckedChangedBinding(
            [NotNull] this IItemReference<WeekDayFragmentViewHolder> weekDayFragmentReference)
        {
            if (weekDayFragmentReference == null)
            {
                throw new ArgumentNullException(nameof(weekDayFragmentReference));
            }

            return new TargetItemOneWayCustomBinding<WeekDayFragmentViewHolder, DayOfWeeksFlags>(
                weekDayFragmentReference,
                (holder, weeks) =>
                {

                    holder.Monday.Checked = false;
                    holder.Tuesday.Checked = false;
                    holder.Wednesday.Checked = false;
                    holder.Thursday.Checked = false;
                    holder.Friday.Checked = false;
                    holder.Suturday.Checked = false;
                    holder.Sunday.Checked = false;

                    if (weeks.HasFlag(DayOfWeeksFlags.Monday))
                    {
                        holder.Monday.Checked = true;
                    }

                    if (weeks.HasFlag(DayOfWeeksFlags.Tuesday))
                    {
                        holder.Tuesday.Checked = true;
                    }

                    if (weeks.HasFlag(DayOfWeeksFlags.Wednesday))
                    {
                        holder.Wednesday.Checked = true;
                    }

                    if (weeks.HasFlag(DayOfWeeksFlags.Thursday))
                    {
                        holder.Thursday.Checked = true;
                    }

                    if (weeks.HasFlag(DayOfWeeksFlags.Friday))
                    {
                        holder.Friday.Checked = true;
                    }

                    if (weeks.HasFlag(DayOfWeeksFlags.Saturday))
                    {
                        holder.Suturday.Checked = true;
                    }

                    if (weeks.HasFlag(DayOfWeeksFlags.Sunday))
                    {
                        holder.Sunday.Checked = true;
                    }
                },
                () => "CheckedChanged");
        }


        public static TargetItemBinding<WeekDayFragmentViewHolder, DayOfWeeksFlags> WeekdayCheckedAndCheckedChangedBinding(
            [NotNull] this IItemReference<WeekDayFragmentViewHolder> weekDayFragemntReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (weekDayFragemntReference == null)
            {
                throw new ArgumentNullException(nameof(weekDayFragemntReference));
            }

            return new TargetItemTwoWayCustomBinding<WeekDayFragmentViewHolder, DayOfWeeksFlags, CompoundButton.CheckedChangeEventArgs>(
                weekDayFragemntReference,
                (holder, handler) =>
                {
                    holder.Monday.CheckedChange += handler;
                    holder.Tuesday.CheckedChange += handler;
                    holder.Wednesday.CheckedChange += handler;
                    holder.Thursday.CheckedChange += handler;
                    holder.Friday.CheckedChange += handler;
                    holder.Suturday.CheckedChange += handler;
                    holder.Sunday.CheckedChange += handler;
                },
                (holder, handler) =>
                {
                    holder.Monday.CheckedChange -= handler;
                    holder.Tuesday.CheckedChange -= handler;
                    holder.Wednesday.CheckedChange -= handler;
                    holder.Thursday.CheckedChange -= handler;
                    holder.Friday.CheckedChange -= handler;
                    holder.Suturday.CheckedChange -= handler;
                    holder.Sunday.CheckedChange -= handler;
                },
                (holder, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        holder.Monday.Enabled = canExecuteCommand;
                        holder.Tuesday.Enabled = canExecuteCommand;
                        holder.Wednesday.Enabled = canExecuteCommand;
                        holder.Thursday.Enabled = canExecuteCommand;
                        holder.Friday.Enabled = canExecuteCommand;
                        holder.Suturday.Enabled = canExecuteCommand;
                        holder.Sunday.Enabled = canExecuteCommand;
                    }
                },
                (holder, args) =>
                {
                    DayOfWeeksFlags weeks = DayOfWeeksFlags.None;

                    if (holder.Monday.Checked)
                    {
                        weeks = weeks | DayOfWeeksFlags.Monday;
                    }

                    if (holder.Tuesday.Checked)
                    {
                        weeks = weeks | DayOfWeeksFlags.Tuesday;
                    }

                    if (holder.Wednesday.Checked)
                    {
                        weeks = weeks | DayOfWeeksFlags.Wednesday;
                    }

                    if (holder.Thursday.Checked)
                    {
                        weeks = weeks | DayOfWeeksFlags.Thursday;
                    }

                    if (holder.Friday.Checked)
                    {
                        weeks = weeks | DayOfWeeksFlags.Friday;
                    }

                    if (holder.Suturday.Checked)
                    {
                        weeks = weeks | DayOfWeeksFlags.Saturday;
                    }

                    if (holder.Sunday.Checked)
                    {
                        weeks = weeks | DayOfWeeksFlags.Sunday;
                    }

                    return weeks;
                },
                (holder, weeks) =>
                {
                    holder.Monday.Checked = false;
                    holder.Tuesday.Checked = false;
                    holder.Wednesday.Checked = false;
                    holder.Thursday.Checked = false;
                    holder.Friday.Checked = false;
                    holder.Suturday.Checked = false;
                    holder.Sunday.Checked = false;

                    if (weeks.HasFlag(DayOfWeeksFlags.Monday))
                    {
                        holder.Monday.Checked = true;
                    }

                    if (weeks.HasFlag(DayOfWeeksFlags.Tuesday))
                    {
                        holder.Tuesday.Checked = true;
                    }

                    if (weeks.HasFlag(DayOfWeeksFlags.Wednesday))
                    {
                        holder.Wednesday.Checked = true;
                    }

                    if (weeks.HasFlag(DayOfWeeksFlags.Thursday))
                    {
                        holder.Thursday.Checked = true;
                    }

                    if (weeks.HasFlag(DayOfWeeksFlags.Friday))
                    {
                        holder.Friday.Checked = true;
                    }

                    if (weeks.HasFlag(DayOfWeeksFlags.Saturday))
                    {
                        holder.Suturday.Checked = true;
                    }

                    if (weeks.HasFlag(DayOfWeeksFlags.Sunday))
                    {
                        holder.Sunday.Checked = true;
                    }
                },
                () => "CheckedChanged");
        }
    }
}