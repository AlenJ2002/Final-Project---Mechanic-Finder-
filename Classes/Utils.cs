namespace FinalAssignment.Classes {
    internal class Utils {

        internal Boolean validatePage(ContentPage contentPageIn) {
            Boolean flag = true;
            foreach (Element e in contentPageIn.GetVisualTreeDescendants()) {
                if (e.GetType() == typeof(Entry)) {
                    Entry entry = (Entry) e;
                    if (String.IsNullOrEmpty(entry.Text)) {
                        this.setErrorColor(entry);
                        flag = false;
                    } else {
                        this.setPrimaryColor(entry);
                    }
                } else if (e.GetType() == typeof(Picker)) {
                    Picker picker = (Picker) e;
                    if (picker.SelectedItem == null) {
                        this.setErrorColor(picker);
                        flag = false;
                    } else {
                        this.setPrimaryColor(picker);
                    }
                }
            }

            if (!flag) {
                contentPageIn.DisplayAlert("Error", "You must fill out all fields.", "oops");
            }

            return flag;
        }

        private void setPrimaryColor(View v) {
            v.BackgroundColor = this.getPrimaryColor();
        }

        private void setErrorColor(View v) {
            v.BackgroundColor = Color.FromRgb(255, 0, 0);
        }

        public Color getPrimaryColor() {
            if (App.Current.Resources.TryGetValue("Primary", out Object theColor)) {
                return (Color)theColor;
            }

            return null;
        }
    }
}
