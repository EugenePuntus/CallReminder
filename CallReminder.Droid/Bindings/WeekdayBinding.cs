using System;
using System.Collections.Generic;
using Android.Widget;
using CallReminder.Droid.Views;
using FlexiMvvm.Bindings;
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;

namespace CallReminder.Droid.Bindings
{
    internal static class WeekdayBinding
    {
        public static TargetItemBinding<WeekDayFragmentViewHolder, IEnumerable<DayOfWeek>> WeekdayCheckedChangedBinding(
            [NotNull] this IItemReference<WeekDayFragmentViewHolder> weekDayFragemntReference)
        {
            if (weekDayFragemntReference == null)
            {
                throw new ArgumentNullException(nameof(weekDayFragemntReference));
            }

            return new TargetItemOneWayCustomBinding<WeekDayFragmentViewHolder, IEnumerable<DayOfWeek>>(
                weekDayFragemntReference,
                (holder, weeks) =>
                {

                    holder.Monday.Checked = false;
                    holder.Tuesday.Checked = false;
                    holder.Wednesday.Checked = false;
                    holder.Thursday.Checked = false;
                    holder.Friday.Checked = false;
                    holder.Suturday.Checked = false;
                    holder.Sunday.Checked = false;

                    foreach (var week in weeks)
                    {
                        switch (week)
                        {
                            case DayOfWeek.Monday:
                                holder.Monday.Checked = true;
                                break;

                            case DayOfWeek.Tuesday:
                                holder.Tuesday.Checked = true;
                                break;

                            case DayOfWeek.Wednesday:
                                holder.Wednesday.Checked = true;
                                break;

                            case DayOfWeek.Thursday:
                                holder.Thursday.Checked = true;
                                break;

                            case DayOfWeek.Friday:
                                holder.Friday.Checked = true;
                                break;

                            case DayOfWeek.Saturday:
                                holder.Suturday.Checked = true;
                                break;

                            case DayOfWeek.Sunday:
                                holder.Sunday.Checked = true;
                                break;
                        }
                    }
                },
                () => "CheckedChanged");
        }


        public static TargetItemBinding<WeekDayFragmentViewHolder, IEnumerable<DayOfWeek>> WeekdayCheckedAndCheckedChangedBinding(
            [NotNull] this IItemReference<WeekDayFragmentViewHolder> weekDayFragemntReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (weekDayFragemntReference == null)
            {
                throw new ArgumentNullException(nameof(weekDayFragemntReference));
            }

            return new TargetItemTwoWayCustomBinding<WeekDayFragmentViewHolder,IEnumerable<DayOfWeek>, CompoundButton.CheckedChangeEventArgs>(
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
                    var listWeekday = new List<DayOfWeek>();

                    if (holder.Monday.Checked)
                    {
                        listWeekday.Add(DayOfWeek.Monday);
                    }

                    if (holder.Tuesday.Checked)
                    {
                        listWeekday.Add(DayOfWeek.Tuesday);
                    }

                    if (holder.Wednesday.Checked)
                    {
                        listWeekday.Add(DayOfWeek.Wednesday);
                    }

                    if (holder.Thursday.Checked)
                    {
                        listWeekday.Add(DayOfWeek.Thursday);
                    }

                    if (holder.Friday.Checked)
                    {
                        listWeekday.Add(DayOfWeek.Friday);
                    }

                    if (holder.Suturday.Checked)
                    {
                        listWeekday.Add(DayOfWeek.Saturday);
                    }

                    if (holder.Sunday.Checked)
                    {
                        listWeekday.Add(DayOfWeek.Sunday);
                    }

                    return listWeekday;
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

                    foreach (var week in weeks)
                    {
                        switch (week)
                        {
                            case DayOfWeek.Monday:
                                holder.Monday.Checked = true;
                                break;

                            case DayOfWeek.Tuesday:
                                holder.Tuesday.Checked = true;
                                break;

                            case DayOfWeek.Wednesday:
                                holder.Wednesday.Checked = true;
                                break;

                            case DayOfWeek.Thursday:
                                holder.Thursday.Checked = true;
                                break;

                            case DayOfWeek.Friday:
                                holder.Friday.Checked = true;
                                break;

                            case DayOfWeek.Saturday:
                                holder.Suturday.Checked = true;
                                break;

                            case DayOfWeek.Sunday:
                                holder.Sunday.Checked = true;
                                break;
                        }
                    }
                },
                () => "CheckedChanged");
        }
    }
}