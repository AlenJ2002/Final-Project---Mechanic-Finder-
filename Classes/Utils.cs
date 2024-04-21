namespace FinalAssignment.Classes {

    // various utilities used throughout the program
    internal class Utils {
        internal Boolean validatePage(ContentPage contentPageIn) {
            // validates all entries and pickers on an input page
            // return false for fail
            Boolean flag = true;

            // iterate over all elements
            foreach (Element e in contentPageIn.GetVisualTreeDescendants()) {
                if (e.GetType() == typeof(Entry)) {
                    // validate entry element
                    Entry entry = (Entry) e;
                    if (String.IsNullOrEmpty(entry.Text)) {
                        this.setErrorColor(entry);
                        flag = false;
                    } else {
                        this.setPrimaryColor(entry);
                    }
                } else if (e.GetType() == typeof(Picker)) {
                    //validate picker element
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

        // sets an element to the primary colour
        public void setPrimaryColor(View v) {
            v.BackgroundColor = this.getPrimaryColor();
        }
        
        // sets an element to the error colour (red)
        public void setErrorColor(View v) {
            v.BackgroundColor = Color.FromRgb(255, 0, 0);
        }

        // get the primary colour used in the project
        public Color getPrimaryColor() {
            if (App.Current.Resources.TryGetValue("Primary", out Object theColor)) {
                return (Color)theColor;
            }

            return null;
        }
    }
}

