// Dark Mode Theme Switcher
(function() {
    'use strict';

    const THEME_KEY = 'eShopTheme';
    const LIGHT_THEME = 'light';
    const DARK_THEME = 'dark';

    // Theme manager object
    const ThemeManager = {
        // Get current theme from localStorage or system preference
        getCurrentTheme: function() {
            const savedTheme = localStorage.getItem(THEME_KEY);
            if (savedTheme) {
                return savedTheme;
            }
            
            // Check system preference
            if (window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches) {
                return DARK_THEME;
            }
            
            return LIGHT_THEME;
        },

        // Apply theme to document
        applyTheme: function(theme) {
            if (theme === DARK_THEME) {
                document.documentElement.setAttribute('data-theme', 'dark');
            } else {
                document.documentElement.removeAttribute('data-theme');
            }
            
            // Update toggle button text if it exists
            this.updateToggleButton(theme);
        },

        // Save theme preference
        saveTheme: function(theme) {
            localStorage.setItem(THEME_KEY, theme);
        },

        // Toggle between themes
        toggleTheme: function() {
            const currentTheme = this.getCurrentTheme();
            const newTheme = currentTheme === DARK_THEME ? LIGHT_THEME : DARK_THEME;
            
            this.applyTheme(newTheme);
            this.saveTheme(newTheme);
            
            return newTheme;
        },

        // Update toggle button appearance
        updateToggleButton: function(theme) {
            const toggleBtn = document.querySelector('.theme-toggle');
            if (toggleBtn) {
                if (theme === DARK_THEME) {
                    toggleBtn.innerHTML = '<span class="icon">☀️</span>Light Mode';
                    toggleBtn.setAttribute('aria-label', 'Switch to light mode');
                } else {
                    toggleBtn.innerHTML = '<span class="icon">🌙</span>Dark Mode';
                    toggleBtn.setAttribute('aria-label', 'Switch to dark mode');
                }
            }
        },

        // Initialize theme system
        init: function() {
            // Apply current theme immediately to prevent flash
            const currentTheme = this.getCurrentTheme();
            this.applyTheme(currentTheme);

            // Set up toggle button event listener
            document.addEventListener('DOMContentLoaded', () => {
                const toggleBtn = document.querySelector('.theme-toggle');
                if (toggleBtn) {
                    toggleBtn.addEventListener('click', (e) => {
                        e.preventDefault();
                        this.toggleTheme();
                    });
                }
            });

            // Listen for system theme changes
            if (window.matchMedia) {
                const mediaQuery = window.matchMedia('(prefers-color-scheme: dark)');
                mediaQuery.addListener((e) => {
                    // Only auto-switch if user hasn't manually set a preference
                    if (!localStorage.getItem(THEME_KEY)) {
                        const newTheme = e.matches ? DARK_THEME : LIGHT_THEME;
                        this.applyTheme(newTheme);
                    }
                });
            }
        }
    };

    // Initialize immediately to prevent flash of unstyled content
    ThemeManager.init();

    // Make theme manager globally available
    window.ThemeManager = ThemeManager;
})();