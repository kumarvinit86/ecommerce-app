import React from "react";
import { AppBar, Toolbar, Typography } from '@mui/material';

const Header: React.FC = () => {
  return (
    <AppBar position="static" color="default" elevation={2}>
      <Toolbar sx={{ justifyContent: "space-between" }}>
        {/* Left: App Title */}
        <Typography variant="h6" color="primary" fontWeight="bold">
          eCommerce
        </Typography>
      </Toolbar>
    </AppBar>
  );
};

export default Header;
